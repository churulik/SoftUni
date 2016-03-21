using System;
using _02.Bank.Customers;

namespace _02.Bank.Accounts
{
    public class Mortgage : Account
    {
        public Mortgage(Customer customer, decimal balance, decimal interestRate) : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            if (months < 1)
            {
                throw new ArgumentOutOfRangeException("Enter valid month number.");
            }

            if (months <= 6 && Customer is Individual)
            {
                return 0;
            }

            var calc = this.Formula(months);

            if (months <= 12 && Customer is Company)
            {

                return calc / 2;
            }

            return calc;
        }
    }
}