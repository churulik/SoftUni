using System;
using _02.Bank.Enums;

namespace _02.Bank.Customers
{
    public class Individual : Customer
    {
        private string firstName;
        private string lastName;
        private int age;

        public Individual(string fistName, string lastName, int age, 
            string street, City city, Country country, decimal annualIncome) 
            : base(street, city, country, annualIncome)
        {
            this.FisrtName = fistName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FisrtName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException("Enter valid name.");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException("Enter valid name.");
                }
                this.lastName = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Enter valid age.");
                }
                this.age = value;
            }
        }
    }
}