using System;

namespace _01.HumanStudentWorker
{
    public class Worker : Human
    {
        private decimal weeklySalary;
        private double workHours;

        public Worker(string firstName, string lastName, decimal weeklySalary, double workHours) 
            : base(firstName, lastName)
        {
            this.WeeklySalary = weeklySalary;
            this.WorkHours = workHours;
        }

        public decimal WeeklySalary
        {
            get { return this.weeklySalary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Enter valid weekly salary.");
                }
                this.weeklySalary = value;
            }
        }

        public double WorkHours
        {
            get { return this.workHours; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Enter valid work hours.");
                }
                this.workHours = value;
            }
        }

        public decimal MoneyPerHour()
        {
            var moneyPerHour = this.weeklySalary/(decimal) this.workHours; 
            return moneyPerHour;
        }

        
    }
}