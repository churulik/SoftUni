using System;
using _03.CompanyHierarchy.Interfaces;

namespace _03.CompanyHierarchy.Customers
{
    public class Customer : Person, ICustomer
    {
        private decimal netPurchaseAmount;

        public Customer(int id, string firstName, string lastName, decimal netPurchaseAmount) 
            : base(id, firstName, lastName)
        {
            this.NetPurchaseAmount = netPurchaseAmount;
        }

        public decimal NetPurchaseAmount
        {
            get { return this.netPurchaseAmount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Enter valid net purchase amount.");
                }
                this.netPurchaseAmount = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"Net purchase amount: {this.NetPurchaseAmount}\n";
        }
    }
}