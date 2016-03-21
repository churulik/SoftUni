namespace Abstraction
{
    using System;

    public class Circle : Figure
    {
        private double radius;

        public Circle(double radius) : base (radius)
        {
        }

        protected override double Radius
        {
            get { return this.radius; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.radius), "The circel radius has to be greater than 0.");
                }

                this.radius = value;
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }

       
    }
}
