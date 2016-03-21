using System;
using _02.Bank.Enums;

namespace _02.Bank.Customers
{
    public class Company : Customer
    {
        private int numberOfWorkers;

        public Company(string street, City city, Country country, decimal annualIncome, int numberOfWorkers) 
            : base(street, city, country, annualIncome)
        {
            this.NumberOfWorkers = numberOfWorkers;
        }

        public int NumberOfWorkers
        {
            get { return this.numberOfWorkers; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Eneter valid number of workers.");
                }
                this.numberOfWorkers = value;
            }
        }
    }
}