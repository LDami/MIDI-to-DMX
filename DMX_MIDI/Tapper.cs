using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMX_MIDI
{
    internal class Tapper
    {
        // Events
        public class TapEventArgs(int division) : EventArgs
        {
            public int BeatDivision = division; // 1-8
        }
        public event EventHandler<TapEventArgs> TapEvent; // Called 8 times per beat, new beat on e.BeatDivision == 1
        protected virtual void OnTap(TapEventArgs e)
        {
            TapEvent?.Invoke(this, e);
        }
        public class BPMChangedEventArgs(int bpm) : EventArgs()
        {
            public int newBPM = bpm;
        }
        public event EventHandler<BPMChangedEventArgs> BPMChanged;
        protected virtual void OnBPMChanged(BPMChangedEventArgs e)
        {
            BPMChanged?.Invoke(this, e);
        }


        private Form mainForm; // Used to detect if closed
        private List<long> stepTimers; // Contains each step time from the previous item
        private Stopwatch sw;
        private Stopwatch swThread;
        private Thread tapThread;
        private ThreadStart tapThreadStart;
        private bool threadActive;
        private int currentDivision;

        public Tapper(Form mainForm)
        {
            this.mainForm = mainForm;
            stepTimers = new();
            sw = new();
            sw.Stop();
            currentDivision = 1;
            tapThreadStart = new ThreadStart(() =>
            {
                threadActive = true;
                TapEvent(this, new TapEventArgs(currentDivision));
                swThread = new();
                swThread.Start();
                while (!this.mainForm.IsDisposed && threadActive && stepTimers.Count > 0)
                {
                    try
                    {
                        double avg = stepTimers.Average();
                        if (swThread.ElapsedMilliseconds >= (avg / 8) * currentDivision)
                        {
                            TapEvent(this, new TapEventArgs(currentDivision ++));
                        }
                        if (swThread.ElapsedMilliseconds >= avg)
                        {
                            currentDivision = 1;
                            swThread.Restart();
                        }
                    }
                    catch(Exception ex)
                    {
                        Logger.AddLog("Tapper.cs - Tapper._:E: tapThreadStart has thrown an exception: " + ex.Message);
                    }
                    Thread.Sleep(1);
                }
                threadActive = false;
            });
            threadActive = false;
        }

        public void Reinit()
        {
            stepTimers.Clear();
            sw.Reset();
            this.OnBPMChanged(new BPMChangedEventArgs(0));
        }

        public void Tap()
        {
            if (stepTimers.Count > 10 || sw.ElapsedMilliseconds > 5000)
                this.Reinit();

            if(sw.IsRunning)
            {
                stepTimers.Add(sw.ElapsedMilliseconds);
                sw.Restart();
                if(stepTimers.Count >= 3)
                {
                    double average = stepTimers.Average();
                    Console.WriteLine(average.ToString());
                    this.OnBPMChanged(new BPMChangedEventArgs(Convert.ToInt32(60 / (average / 1000))));
                    if(!threadActive)
                    {
                        tapThread = new Thread(tapThreadStart);
                        tapThread.Start();
                    }
                }
            }
            else
            {
                sw.Start();
            }

        }
    }
}
