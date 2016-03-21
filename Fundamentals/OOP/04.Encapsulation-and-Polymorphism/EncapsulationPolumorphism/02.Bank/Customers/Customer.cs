using System;
using _02.Bank.Enums;

namespace _02.Bank.Customers
{
    public abstract class Customer
    {
        private string street;
        private decimal annualIncome;

        protected Customer(string street, City city, Country country, decimal annualIncome)
        {
            this.Street = street;
            this.City = city;
            this.Country = country;
            this.AnnualIncome = annualIncome;
        }

        public string Street
        {
            get { return this.street; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException("Enter valid street.");
                }
                this.street = value;
            }
        }

        public City City { get; set; }
        public Country Country { get; set; }

        protected decimal AnnualIncome
        {
            get { return this.annualIncome; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Eneter valid annual income.");
                }
                this.annualIncome = value;
            }
        }
    }
}