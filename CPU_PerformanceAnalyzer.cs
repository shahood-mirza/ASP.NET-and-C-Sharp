using System;
using System.Diagnostics;
using System.Threading;
using System.Timers;

namespace CPU_PerformanceAnalyzer
{
    class CPU_PerformanceAnalyzer
    {
        private static CPU_PerformanceAnalyzer cpu = new CPU_PerformanceAnalyzer();
        private PerformanceCounter theCPUCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        private static System.Diagnostics.Stopwatch stopWatch;
        private static TimeSpan time;

        static double error, target, errorSum, lastError, prop, integ, diff, sleepTime, comb, usage;
        static int n, k;

        static void Main(string[] args)
        {
            stopWatch = new System.Diagnostics.Stopwatch();
            time = new TimeSpan();

            errorSum = 0;
            lastError = 0;
            sleepTime = 0;

            target = 15;

            n = 500000;
            k = 10;

            prop = 0.001;
            integ = 0;
            diff = 0;

            initTimer(); //start timer for displaying results ever 2 seconds

            while (true)
            {
                stopWatch.Reset();
                stopWatch.Start();

                comb = fact(n) / (fact(n-k) * fact(k)); //combination calculation, should take longer as time passes
 
                usage = cpu.theCPUCounter.NextValue();

                error = usage - target;

                sleepTime += (prop * error) + (integ * errorSum) + (diff * (error - lastError));
                lastError = error;
                errorSum += error;

                stopWatch.Stop();
                time = stopWatch.Elapsed;

                if(sleepTime >= 0)
                    Thread.Sleep(TimeSpan.FromMilliseconds(sleepTime));
            }
        }

        //calculate factorial of the input
        static double fact(int input)
        {
            double output = 1;
            for (int i=input; i>1; i--)
            {
                output *= i;
            }
            return output;
        }

        //set timer and add the event handler which runs each interval
        static void initTimer()
        {
            System.Timers.Timer myTimer = new System.Timers.Timer();
            myTimer.Elapsed += new ElapsedEventHandler(displayResults);
            myTimer.Interval = 100; //milliseconds
            myTimer.Enabled = true;
        }

        //display the results of the calculations from the main loop
        static void displayResults(object source, ElapsedEventArgs e) {
            Console.Write(n + " choose " + k + " gives " + comb + " combinations\n");
            Console.Write("CPU Usage: " + usage + "\n");
            Console.Write("Target: " + target + "\n");
            Console.Write("Sleep: " + sleepTime + "\n");
            Console.Write("Stopwatch Time: " + time + "\n\n");
        }

    }
}
