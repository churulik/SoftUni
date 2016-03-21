using System;

namespace _02.LaptopShop
{
    public class Laptop : Battery
    {
        private string model;
        private string manufaturer;
        private string processor;
        private string ram;
        private string graphicCard;
        private string hdd;
        private string screen;
        private decimal price;

        public Laptop(string model, decimal price) 
            : this (model, null, null, null, null, null, null, price, null)
        {
            
        }

        public Laptop(string model, string manufacturer, string proccessor, string ram, string graphicCard,
            string hdd, string screen, decimal price) 
            : this (model, manufacturer, proccessor, ram, graphicCard, hdd, screen, price, null)
        {
            
        }

        public Laptop(string model, string manufacturer, string proccessor, string ram, string graphicCard,
            string hdd, string screen, decimal price, Battery battery)
        {
            this.Model = model;
            this.Manufaturer = manufacturer;
            this.Processor = proccessor;
            this.Ram = ram;
            this.GraphicCard = graphicCard;
            this.Hdd = hdd;
            this.Screen = screen;
            this.Price = price;
            this.Battery = battery;
        }

        public string Model
        {
            get { return this.model; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Invald model.");
                }
                this.model = value;
            }
        }

        public string Manufaturer
        {
            get { return this.manufaturer; }
            set
            {
                
                if (value != null && value.Trim() == "")
                {
                    throw new ArgumentException("Invalid manufaturer.");
                }
                this.manufaturer = value;
            }
        }

        public string Processor
        {
            get { return this.processor; }
            set
            {
                if (value != null && value.Trim() == "")
                {
                    throw new ArgumentException("Invalid procssor.");
                }
                this.processor = value;
            }
        }

        public string Ram
        {
            get { return this.ram; }
            set
            {
                if (value != null && value.Trim() == "")
                {
                    throw new ArgumentOutOfRangeException("Invalid RAM.");
                }
                this.ram = value;
            }
        }

        public string GraphicCard
        {
            get { return this.graphicCard; }
            set
            {
                if (value != null && value.Trim() == "")
                {
                    throw new ArgumentException("Invalid graphic card.");
                }
                this.graphicCard = value;
            }
        }

        public string Hdd
        {
            get { return this.hdd; }
            set
            {
                if (value != null && value.Trim() == "")
                {
                    throw new ArgumentException("Invalid HDD.");
                }
                this.hdd = value;
            }
        }

        public string Screen
        {
            get { return this.screen; }
            set
            {
                if (value != null && value.Trim() == "")
                {
                    throw new ArgumentException("Invalid screen.");
                }
                this.screen = value;
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

        public Battery Battery { get; set; }
        

        public override string ToString()
        {
            if (this.Battery != null)
            {
                return $"Model: {this.Model}\n" +
                       $"Manufacturer: {this.Manufaturer}\n" +
                       $"Proccessor: {this.Processor}\n" +
                       $"RAM: {this.Ram}\n" +
                       $"Graphic card: {this.GraphicCard}\n" +
                       $"HDD: {this.Hdd}\n" +
                       $"Screen: {this.Screen}\n" +
                       $"Battery: {this.Battery.Type}, {this.Battery.Cells}-cells, {this.Battery.MAh} mAh\n" +
                       $"Battery life: {this.Battery.Life} hours\n" +
                       $"Price: {this.Price.ToString("0.00")} lv.\n";
            }

            if (this.Manufaturer != null)
            {
                return $"Model: {this.Model}\n" +
                       $"Manufacturer: {this.Manufaturer}\n" +
                       $"Proccessor: {this.Processor}\n" +
                       $"RAM: {this.Ram}\n" +
                       $"Graphic card: {this.GraphicCard}\n" +
                       $"HDD: {this.Hdd}\n" +
                       $"Screen: {this.Screen}\n"+
                       $"Price: {this.Price.ToString("0.00")} lv.\n";
            }

            return $"Model: {this.Model}\n" +
                   $"Price: {this.Price.ToString("0.00")} lv.\n";
        }
    }
}