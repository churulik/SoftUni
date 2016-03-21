using System;
using _02.Bank.Customers;
using _02.Bank.Interfaces;

namespace _02.Bank.Accounts
{
    public class Deposit : Account, IDeposit
    {
        public Deposit(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            if (months < 1)
            {
                throw new ArgumentOutOfRangeException("Enter valid month number.");
            }
            
            if (this.Balance > 0 && this.Balance < 1000)
            {
                return 0;
            }

            var calc = this.Formula(months);
            return calc;

        }

        public decimal Withdraw(decimal sum)
        {
            if (this.Balance - sum < 0)
            {
                throw new ArgumentOutOfRangeException("Not enough money");
            }
            return this.Balance -= sum;
        }
    }
}