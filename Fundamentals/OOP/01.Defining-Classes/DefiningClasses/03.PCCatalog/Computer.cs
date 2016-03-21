using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;

namespace _03.PCCatalog
{
    public class Computer
    {
        private string name;
        private decimal price;

        public Computer(string name, decimal price) : this(name, null, price)
        {

        }

        public Computer(string name, ICollection<Component> components, decimal price)
        {
            this.Name = name;
            this.Components = components;
            this.Price = price;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Invalid name.");
                }
                this.name = value;
            }
        }

        public ICollection<Component> Components { get; set; }

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

        public override string ToString()
        {
            if (this.Components != null)
            {
                decimal componentsPrice = 0;

                var output = string.Format("PC Name: {0}\n" +
                                           "Components Information:\n", this.Name);
                
                foreach (var component in this.Components)
                {
                    output += string.Format(System.Globalization.CultureInfo.GetCultureInfo("bg-BG"),
                        "\tName: {0}\n" +
                        "\tDetails: {1}\n" +
                        "\tPrice {2:0.00} lv.\n\n",
                        component.Name, component.Details ?? "N/A", component.Price);
                    componentsPrice += component.Price;
                }
                output += string.Format(System.Globalization.CultureInfo.GetCultureInfo("bg-BG"), "Components Price: {0:0.00} lv.\n", componentsPrice);
                output += string.Format(System.Globalization.CultureInfo.GetCultureInfo("bg-BG"),"Total Price: {0:0.00} lv.\n", this.Price);
                
                return output;
            }

            return string.Format(System.Globalization.CultureInfo.GetCultureInfo("bg-BG"), 
                "PC Name: {0}\n"+
                "Compnents Information: None\n" +
                "TotalPrice: {1:0.00} lv.\n", 
                this.Name, this.Price);

        }
    }
}