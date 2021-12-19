using System;
using System.IO;
using System.Text;
using System.Threading;

namespace DMX_MIDI
{
    class Logger
    {
        private static bool DEBUG = false;

        private static Mutex logMutex = new Mutex();

        private static string logFolder = Path.GetTempPath() + "\\dmx_midi";
        private static string logFile = logFolder + "\\output.log";
        private static string tempLog = "";

        public static void Init()
        {
            if (!Directory.Exists(logFolder))
                Directory.CreateDirectory(logFolder);

            if (File.Exists(logFile))
                File.WriteAllText(logFile, "");

            Console.WriteLine("Logger initialized to: " + logFile);
        }

        public static void AddLog(int text) => AddLog(text.ToString());
		public static void AddLog(string text)
        {
            if (DEBUG) Console.WriteLine("[" + DateTime.Now + "] " + text);
            tempLog += text + '\n';
            
            Thread logThread = new Thread(new ThreadStart(AddLogThread));
            logThread.Priority = ThreadPriority.AboveNormal;
            logThread.Start();
            
            //AddLogThread();
        }

        private static void AddLogThread()
        {
            string toWrite = tempLog;
            tempLog = "";
            if (toWrite.Length > 0)
            {
                //Console.WriteLine("Waiting mutex ...");
                if (logMutex.WaitOne(2000))
                {
                    //Console.WriteLine("Having mutex, processing ...");
                    while (!IsFileReadable(new FileInfo(logFile)))
                    {
                        Thread.Sleep(100);
                    }
                    //Console.WriteLine("Adding log");
                    try
                    {
                        FileStream fs = File.Open(logFile, FileMode.Append, FileAccess.Write);

                        byte[] data;

                        string[] arr = toWrite.Split('\n');
                        if (arr.Length > 0)
                        {
                            foreach (string str in arr)
                            {
                                if(str.Length > 0)
                                {
                                    data = new UTF8Encoding(true).GetBytes("[" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff") + "] " + str + "\r\n");
                                    foreach (byte databyte in data)
                                        fs.WriteByte(databyte);
                                }
                            }
                        }
                        else
                        {
                            data = new UTF8Encoding(true).GetBytes("[" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff") + "] " + toWrite + "\r\n");
                            foreach (byte databyte in data)
                                fs.WriteByte(databyte);
                        }

                        fs.FlushAsync();
                        fs.Close();
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine("Cant open log file: " + e);
                    }
                    finally
                    {
                        //Console.WriteLine("Releasing mutex ...");
                        logMutex.ReleaseMutex();
                        //Console.WriteLine("Mutex free");
                    }
                }
                else
                    Console.WriteLine("Cannot get mutex !");
            }
        }
        private static Boolean IsFileReadable(FileInfo file)
        {
            if (file.Exists)
            {
                try
                {
                    using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        stream.Close();
                    }
                }
                catch (IOException)
                {
                    //the file is unavailable because it is:
                    //still being written to
                    //or being processed by another thread
                    //or does not exist (has already been processed)
                    Console.WriteLine("IsfileReadable: false (IOException)");
                    return false;
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("IsfileReadable: false (UnauthorizedAccessException)");
                    return false;
                }

                //file is not locked
                return true;
            }
            else
            {
                Console.WriteLine("IsfileReadable: true (not exists)");
                return true;
            }
        }

    }
}
