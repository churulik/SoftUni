using System;

namespace _02.LaptopShop
{
    public class Battery
    {
        private string type;
        private int cells;
        private int mah;
        private double life;

        public string Type
        {
            get { return this.type; }
            set
            {
                if (value != null && value.Trim() == "")
                {
                    throw new ArgumentException("Invalid battery type.");
                }
                this.type = value;
            }
        }

        public int Cells
        {
            get { return this.cells; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid battery cells.");
                }
                this.cells = value;
            }
        }

        public int MAh
        {
            get { return this.mah; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid mAh.");
                }
                this.mah = value;
            }
        }

        public double Life
        {
            get { return this.life; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid battery life.");
                }
                this.life = value;
            }
        }
    }
}