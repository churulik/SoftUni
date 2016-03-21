using System;
using System.Threading;
using System.Threading.Tasks;

namespace _03.AsynchronousTimer
{
    public class AsyncTimer
    {
        public event Action OnTick;

        private int ticks;
        private int interval;
        private Thread thread;

        public AsyncTimer(Action onTick, int ticks, int inteval)
        {
            this.OnTick = onTick;
            this.Ticks = ticks;
            this.Interval = inteval;
        }

        public int Ticks
        {
            get { return this.ticks; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Enter valid ticks.");
                }
                this.ticks = value;
            }
        }
       
        public int Interval
        {
            get { return this.interval; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Enter valid intervals.");
                }
                this.interval = value;
            }

        }
        public void Start()
        {
            this.thread = new Thread(this.Method);            
            this.thread.Start();
        }

        private void Method()
        {
            while (this.Ticks > 0)
            {
                Thread.Sleep(this.Interval);
                if (OnTick != null)
                {
                   this.OnTick();
                }
                this.Ticks--;
            }
            this.thread.Abort();
        }
    }
}