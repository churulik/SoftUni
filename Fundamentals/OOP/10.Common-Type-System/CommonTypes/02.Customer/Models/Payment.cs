using System;

namespace _02.Customer.Models
{
    public class Payment
    {
        private string productName;
        private decimal price;

        public Payment(string productName, decimal price)
        {
            this.ProducName = productName;
            this.Price = price;
        }

        public string ProducName
        {
            get { return this.productName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.productName), "Enter valid product name.");
                }
                this.productName = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (price < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.price), "Enter valid price.");
                }
                this.price = value;
            }
        } 
    }
}