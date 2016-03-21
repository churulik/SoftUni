using System;

namespace _03.PCCatalog
{
    public class Component
    {
        private string name;
        private string details;
        private decimal price;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Invalid component name.");
                }
                this.name = value;
            }
        }

        public string Details
        {
            get { return this.details; }
            set
            {
                if (value != null && value.Trim() == "")
                {
                    throw new ArgumentException("Invalid component details");
                }
                this.details = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid price.");
                }
                this.price = value;
            }
        }
    }
}