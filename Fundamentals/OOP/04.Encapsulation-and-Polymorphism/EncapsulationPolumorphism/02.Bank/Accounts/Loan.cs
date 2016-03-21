using System;
using _02.Bank.Customers;

namespace _02.Bank.Accounts
{
    public class Loan : Account
    {
        public Loan(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            if (months < 1)
            {
                throw new ArgumentOutOfRangeException("Enter valid month number.");
            }

            if ((months <= 3 && Customer is Individual) ||
                (months <= 2 && Customer is Company))
            {
                return 0;
            }

            var calc = this.Formula(months);
            return calc;
        }
    }
}