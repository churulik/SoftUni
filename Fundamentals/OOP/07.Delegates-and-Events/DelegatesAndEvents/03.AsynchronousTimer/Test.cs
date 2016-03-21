using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace _03.AsynchronousTimer
{
    class Test
    {
        public static void TickMethod()
        {
            Console.WriteLine("Tick");
        }
        static void Main()
        {
            var timer = new AsyncTimer(Timer_OnTick, 10, 1000);
            timer.Start();

            //test
            const int thr = 200;
            var count = (timer.Ticks * timer.Interval) / thr;
            
            for (int i = 0; i < count; i++)
            {
                Thread.Sleep(thr);
                Console.WriteLine(i);
            }
        }

        private static void Timer_OnTick()
        {
            Console.WriteLine("Tick");
        }
    }
}
