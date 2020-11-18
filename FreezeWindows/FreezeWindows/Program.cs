using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace HangWindows
{
    class Program
    {
        private static List<Thread> threads;
        private static int totalThreads = 0;
        private static bool startThreadCreation = true;
        private static StringBuilder allocHighMemory;

        static void Main(string[] args)
        {
            if(args.Length == 1)
            {
                AllocateHighMemory();
                LoadCpuForHighUsage(Int32.Parse(args[0]));
            }
            else
            {
                Console.WriteLine("Please enter the duration for high CPU load.");
            }
            Environment.Exit(0);
        }

        private static void AllocateHighMemory()
        {
            allocHighMemory = new StringBuilder();
            for (int i = 0; i < 900000; i++)
            {
                allocHighMemory.AppendLine(new String('H', 1000));
            }
        }

        private static void LoadCpuForHighUsage(int waitPeriod)
        {
            var timer = new System.Timers.Timer(10 * 1000);
            Console.WriteLine("Waiting 10s before creating threads for high CPU load.");
            timer.Elapsed += (sender, e) =>
            {
                timer.Stop(); timer.Dispose();
                CreateThreadsForHighCpuUsage(waitPeriod);
            };
            timer.Start();
            Thread.Sleep(12000);
            while (startThreadCreation) ;
        }

        private static void CreateThreadsForHighCpuUsage(int waitPeriod)
        {
            Console.WriteLine("Threads will be created and killed after {0}s.", waitPeriod);
            var timer = new System.Timers.Timer(waitPeriod * 1000);
            timer.Elapsed += OnTimerElapsed;
            timer.Start();

            threads = new List<Thread>();
            while (startThreadCreation)
            {
                var thread = new Thread(ExecuteThread);
                thread.IsBackground = true;
                thread.Priority = ThreadPriority.AboveNormal;
                threads.Add(thread);
                thread.Start();
                totalThreads++;
            }
        }

        private static void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("{0} threads are created.", totalThreads);

            startThreadCreation = false;

            Console.WriteLine("Threads creation stopped and {0} threads will be aborted", threads.Count);

            var timer = (System.Timers.Timer)sender;
            timer.Stop();
            timer.Dispose();

            foreach(var th in threads)
            {
                th.Abort();
            }
        }

        static void ExecuteThread()
        {
            Console.WriteLine("Thread {0} started", Thread.CurrentThread.ManagedThreadId);
            var random = new Random();
            var number = 0;
            while(true)
            {
                number = random.Next(1000000);
                IsPrime(number);
            }
        }

        static bool IsPrime(int number)
        {
            var n = number;
            if (n <= 1) return false;
            if (n <= 3) return true;
            if (n % 2 == 0 || n % 3 == 0) return false;

            for (int i = 5; i * i <= n; i = i + 6)
            {
                if (n % i == 0 || n % (i + 2) == 0) return false;
            }

            return true;
        }
    }
}
