namespace Abstraction
{
    using System;

    public class Rectangle : Figure
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
            : base(width, height)
        {
        }

        protected override double Width
        {
            get { return this.width; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.width), "The rectangle width has to be bigger than 0.");
                }

                this.width = value;
            }
        }

        protected override double Height
        {
            get { return this.height; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.height), "The rectangle height has to be bigger than 0.");
                }

                this.height = value;
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
