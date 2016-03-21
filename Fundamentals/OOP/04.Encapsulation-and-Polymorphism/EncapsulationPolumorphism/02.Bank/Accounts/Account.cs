using System;
using _02.Bank.Customers;
using _02.Bank.Interfaces;

namespace _02.Bank.Accounts
{
    public abstract class Account : IAccount
    {
        private Customer customer;
        private decimal balance;
        private decimal interestRate;

        protected Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        protected Customer Customer
        {
            get { return this.customer; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Customer cannot be empty.");
                }
                this.customer = value;
            }
        }

        protected decimal Balance
        {
            get { return this.balance; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The balance cannot be negative.");
                }
                this.balance = value;
            }
        }

        protected decimal InterestRate
        {
            get { return this.interestRate; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Interest rate cannot be negative");
                }
                this.interestRate = value;
            }
        }

        protected decimal Formula(int months)
        {
            var rate = this.InterestRate / 100;
            var period = (decimal) months / 12;
            var roundPeriod = Math.Round(period, 2);
            var calc = this.Balance * rate * roundPeriod;
            var calcRounr = Math.Round(calc, 2);
            return calcRounr;
        }

        public decimal Deposite(decimal sum)
        {
            return this.Balance += sum;
        }

        public abstract decimal CalculateInterest(int months);
    }
}