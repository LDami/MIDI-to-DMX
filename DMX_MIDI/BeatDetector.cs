﻿using ManagedBass;
using ManagedBass.Wasapi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
 * 
 * Created from https://codereview.stackexchange.com/questions/78589/beat-detection-algorithm-implementation
 * With help from https://www.parallelcube.com/web/wp-content/uploads/2018/03/BeatDetectionAlgorithms.pdf
 * 
 * */

namespace DMX_MIDI
{
    public enum SensivityLevel
    {
        VERY_LOW = 120,
        LOW = 110,
        NORMAL = 100,
        HIGH = 80,
        VERY_HIGH = 70
    };

    public sealed class SpectrumBeatDetector
    {
        #region Fields

        // Constants
        private const int HISTORY = 43;

        // Events
        public delegate void BeatDetectedHandler(byte Value);
        private event BeatDetectedHandler OnDetected;

        // Public data
        public string DeviceName { get { return BassWasapi.GetDeviceInfo(_DeviceCode).Name; } }

        // Threading
        private Thread _AnalysisThread;

        // BASS Process
        private WasapiProcedure _WasapiProcess = new(Process);

        // Analysis settings
        private int _SamplingRate;
        private int _DeviceCode;

        // Analysis data
        private float[] _FFTData = new float[4096];
        private double[] _History = new double[HISTORY];
        private double _Variance; // Used to help detection with sound variance

        #endregion

        #region Setup methods

        public SpectrumBeatDetector(int DeviceCode, int SamplingRate = 44100)
        {
            _SamplingRate = SamplingRate;
            _DeviceCode = DeviceCode;
            Init();
        }

        // BASS initialization method
        private void Init()
        {
            bool result = false;

            // Initialize BASS
            result = Bass.Init(0, _SamplingRate, DeviceInitFlags.Stereo);

            if (!result)
            {
                throw new BassException(Bass.LastError);
            }

            // Initialize WASAPI
            //result = BassWasapi.Init(_DeviceCode, 48000, 2, WasapiInitFlags.Buffer, 0, 0.010f, _WasapiProcess);
            result = BassWasapi.Init(_DeviceCode, 0, 0, WasapiInitFlags.Buffer, 1f, 0.05f, _WasapiProcess);
            
            
            if (!result)
            {
                throw new BassException(Bass.LastError);
            }

            BassWasapi.Start();
            Thread.Sleep(500);
        }


        ~SpectrumBeatDetector()
        {
            // Kill working thread and clean after BASS
            if (_AnalysisThread != null && _AnalysisThread.IsAlive)
            {
                _AnalysisThread.Abort();
            }

            Free();
        }

        #endregion

        #region BASS-dedicated Methods

        // WASAPI callback, required for continuous recording
        private static int Process(IntPtr buffer, int length, IntPtr user)
        {
            return length;
        }

        // Cleans after BASS
        public void Free()
        {
            BassWasapi.Free();
            Bass.Free();
        }

        #endregion

        #region Analysis public methods

        // Starts a new Analysis Thread
        public void StartAnalysis()
        {
            // Kills currently running analysis thread if alive
            if (_AnalysisThread != null && _AnalysisThread.IsAlive)
            {
                _AnalysisThread.Abort();
            }

            // Starts a new high-priority thread
            _AnalysisThread = new Thread(delegate ()
            {
                while (true)
                {
                    Thread.Sleep(5);
                    PerformAnalysis();
                }
            });

            _AnalysisThread.Priority = ThreadPriority.Highest;
            _AnalysisThread.Start();
        }

        // Kills running thread
        public void StopAnalysis()
        {
            if (_AnalysisThread != null && _AnalysisThread.IsAlive)
            {
                _AnalysisThread.Abort();
            }
        }

        #endregion

        #region Event handling

        public void Subscribe(BeatDetectedHandler Delegate)
        {
            OnDetected += Delegate;
        }

        public void UnSubscribe(BeatDetectedHandler Delegate)
        {
            OnDetected -= Delegate;
        }

        #endregion

        #region Analysis private methods

        // Shifts history n places to the right
        private void ShiftHistory(int n)
        {
            for (int j = HISTORY - 1 - n; j >= 0; j--)
            {
                _History[j + n] = _History[j];
            }
        }

        // Performs FFT analysis in order to detect beat
        private void PerformAnalysis()
        {
            int level = BassWasapi.GetLevel();

            // Get FFT
            int ret = BassWasapi.GetData(_FFTData, (int)DataFlags.FFT1024 | (int)DataFlags.FFTComplex); //get channel fft data
            if (ret < -1) return;

            // Calculate the energy of every result
            float actualEnergy = 0;

            for (int i = 2; i < 2048; i = i + 2)
            {
                float real = _FFTData[i];
                float complex = _FFTData[i + 1];
                actualEnergy += (float)Math.Sqrt((double)(real * real + complex * complex));
            }

            double historyAverage = CalculateAverage(_History);

            // Calculate the average level of all history and calculate the variance
            CalculateVariance(_History, historyAverage);

            // Shift the history register and save new values
            ShiftHistory(1);

            _History[0] = actualEnergy;

            // Detect beat basing on FFT results
            DetectBeat(historyAverage, actualEnergy, level);
        }

        /// <summary>
        /// Calculate the average of all history energies
        /// </summary>
        /// <param name="history">Array of all history energies</param>
        /// <returns>The average of squared energies</returns>
        private double CalculateAverage(double[] history)
        {
            double sumOfHistoryEnergies = 0;
            for (int i = 0; i < HISTORY; i++)
            {
                sumOfHistoryEnergies += Math.Pow(history[i], 2);
            }
            return sumOfHistoryEnergies / HISTORY;
        }

        /// <summary>
        /// Calculate the variance between history energies
        /// </summary>
        /// <param name="history">Array of all history energies</param>
        /// <param name="historyAverage">Average of history energies</param>
        private void CalculateVariance(double[] history, double historyAverage)
        {
            double sumOfDiffHistoryLvlAndAverage = 0;
            for (int i = 0; i < HISTORY; i++)
            {
                sumOfDiffHistoryLvlAndAverage += Math.Pow(history[i] - historyAverage, 2);
            }
            _Variance = sumOfDiffHistoryLvlAndAverage / HISTORY;
        }

        /// <summary>
        /// Detects beat basing on analysis result
        /// </summary>
        /// <param name="energy">Energy of the actual sample</param>
        /// <param name="volume">Actual volume level detected by BassWasapi</param>
        /// <returns></returns>
        private byte DetectBeat(double historyAverage, double energy, int volume)
        {
            byte result = 0;
            double volumelevel = (double)volume / 32768 * 100;   // Volume level in %
            //Logger.AddLog("volume: " + volumelevel);

            double C = (-0.0025714 * _Variance) + 1.5142857;
            C = C * 1.15;

            // Compare energies with C*average
            if (Math.Pow(energy, 2) > (C * historyAverage) && energy > 0.5)   // Second rule is for noise reduction
            {
                result = 1;
            }

            if (result > 0 && volumelevel > 1500f)
            {
                OnDetected(result);
            }

            return result;
        }

        #endregion

    }
}