using System;

namespace _03.CompanyHierarchy.Employees.RegularEmployees.Occupations
{
    public class Sale
    {
        private string productName;
        private decimal price;

        public Sale(string productName, DateTime date, decimal price)
        {
            this.ProductName = productName;
            this.Date = date;
            this.Price = price;
        }

        public string ProductName
        {
            get { return this.productName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Enter a valid product name.");
                }
                this.productName = value;
            }
        }
        public DateTime Date { get; set; }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Enter valid price.");
                }
                this.price = value;
            }
        } 
    }
}