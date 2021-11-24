using ManagedBass;
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
        private const int BANDS = 10;
        private const int HISTORY = 50;

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
        private SensivityLevel _BASSSensivity;
        private SensivityLevel _MIDSSensivity;

        // Analysis data
        private float[] _FFTData = new float[4096];
        private double[,] _History = new double[BANDS, HISTORY];

        #endregion

        #region Setup methods

        public SpectrumBeatDetector(int DeviceCode, int SamplingRate = 44100, SensivityLevel BASSSensivity = SensivityLevel.NORMAL, SensivityLevel MIDSSensivity = SensivityLevel.NORMAL)
        {
            _SamplingRate = SamplingRate;
            _BASSSensivity = BASSSensivity;
            _MIDSSensivity = MIDSSensivity;
            _DeviceCode = DeviceCode;
            Init();
        }

        // BASS initialization method
        private void Init()
        {
            bool result = false;


            // Initialize BASS on default device
            result = Bass.Init(0, _SamplingRate, DeviceInitFlags.NoSpeakerAssignment, IntPtr.Zero);
            /*
            for(int i=0; i < 10; i++)
            {
                Console.WriteLine(i);
                Console.WriteLine(Bass.GetDeviceInfo(i).Driver);
                Console.WriteLine(Bass.GetDeviceInfo(i).IsEnabled);
                Console.WriteLine(Bass.GetDeviceInfo(i).IsDefault);
                Console.WriteLine(Bass.GetDeviceInfo(i).Name);
            }*/
            if (!result)
            {
                throw new BassException(Bass.LastError);
            }

            // Initialize WASAPI
            result = BassWasapi.Init(_DeviceCode, 48000, 2, WasapiInitFlags.Buffer, 0.1f, 0.005f, _WasapiProcess, IntPtr.Zero);
            Console.WriteLine("chan: " + BassWasapi.GetDeviceInfo(_DeviceCode).MixChannels);
            Console.WriteLine("freq: " + BassWasapi.GetDeviceInfo(_DeviceCode).MixFrequency);
            Console.WriteLine("mute: " + BassWasapi.GetMute(WasapiVolumeTypes.Device));
            /*
            for(int i=0; i < 100; i++)
            {
                Console.WriteLine(i);
                if (BassWasapi.GetDeviceInfo(i).IsEnabled)
                {
                    Console.WriteLine(BassWasapi.GetDeviceInfo(i).Type);
                    Console.WriteLine(BassWasapi.GetDeviceInfo(i).MixChannels);
                    Console.WriteLine(BassWasapi.GetDeviceInfo(i).IsDefault);
                    Console.WriteLine(BassWasapi.GetDeviceInfo(i).Name);
                }
            }
            */
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

        // Sensivity Setters
        public void SetBassSensivity(SensivityLevel Sensivity)
        {
            _BASSSensivity = Sensivity;
        }

        public void SetMidsSensivity(SensivityLevel Sensivity)
        {
            _MIDSSensivity = Sensivity;
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
                    //Stopwatch SW = new Stopwatch();
                    //SW.Start();
                    Thread.Sleep(5);
                    PerformAnalysis();
                    //SW.Stop();
                    //Console.WriteLine(SW.Elapsed);
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
            for (int i = 0; i < BANDS; i++)
            {
                for (int j = HISTORY - 1 - n; j >= 0; j--)
                {
                    _History[i, j + n] = _History[i, j];
                }
            }
        }

        // Performs FFT analysis in order to detect beat
        private void PerformAnalysis()
        {
            // Specifes on which result end which band (dividing it into 10 bands)
            // 19 - bass, 187 - mids, rest is highs
            int[] BandRange = { 4, 8, 18, 38, 48, 94, 140, 186, 466, 1022, 22000 };
            double[] BandsTemp = new double[BANDS];
            int n = 0;
            int level = BassWasapi.GetLevel();

            // Get FFT
            int ret = BassWasapi.GetData(_FFTData, (int)DataFlags.FFT1024 | (int)DataFlags.FFTComplex); //get channel fft data
            if (ret < -1) return;

            // Calculate the energy of every result and divide it into subbands
            float sum = 0;

            for (int i = 2; i < 2048; i = i + 2)
            {
                float real = _FFTData[i];
                float complex = _FFTData[i + 1];
                sum += (float)Math.Sqrt((double)(real * real + complex * complex));

                if (i == BandRange[n])
                {
                    BandsTemp[n++] = (BANDS * sum) / 1024;
                    sum = 0;
                }
            }

            // Detect beat basing on FFT results
            DetectBeat(BandsTemp, level);

            // Shift the history register and save new values
            ShiftHistory(1);

            for (int i = 0; i < BANDS; i++)
            {
                _History[i, 0] = BandsTemp[i];
            }
        }

        // Calculate the average value of every band
        private double[] CalculateAverages()
        {
            double[] avg = new double[BANDS];

            for (int i = 0; i < BANDS; i++)
            {
                double sum = 0;

                for (int j = 0; j < HISTORY; j++)
                {
                    sum += _History[i, j];
                }

                avg[i] = (sum / HISTORY);
            }

            return avg;
        }

        // Detects beat basing on analysis result
        // Beat detection is marked on the first three bits of the returned value
        private byte DetectBeat(double[] Energies, int volume)
        {
            // Sound height ranges (1, 2 is bass, next 6 is mids)
            int Bass = 3;
            int Mids = 6;

            double[] avg = CalculateAverages();
            byte result = 0;
            double volumelevel = (double)volume / 32768 * 100;   // Volume level in %
            //Console.WriteLine("volume: " + volumelevel);

            for (int i = 0; i < BANDS && result == 0; i++)
            {
                // Set the C parameter
                double C = 0;

                if (i < Bass)
                {
                    C = 2.3 * ((double)_BASSSensivity / 100);
                }
                else if (i < Mids)
                {
                    C = 2.89 * ((double)_MIDSSensivity / 100);
                }
                else
                {
                    C = 3 * ((double)_MIDSSensivity / 100);
                }

                // Compare energies in all bands with C*average
                if (Energies[i] > (C * avg[i]) && volumelevel > 1)   // Second rule is for noise reduction
                {
                    byte res = 0;
                    if (i < Bass)
                    {
                        res = 1;
                    }
                    else if (i < Mids)
                    {
                        res = 2;
                    }
                    else
                    {
                        res = 4;
                    }
                    result = (byte)(result | res);
                }
            }

            if (result > 0)
            {
                OnDetected(result);
            }

            return result;
        }

        #endregion

    }
}