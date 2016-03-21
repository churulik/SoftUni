using System;
using _01.Shapes.Interfaces;

namespace _01.Shapes.Shapes
{
    public class Circle : IShape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        protected double Radius
        {
            get { return this.radius; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The radius cannot be negative.");
                }
                this.radius = value;
            }
        }

        public double CalculateArea()
        {
            var calc = Math.PI*Math.Pow(this.Radius, 2);
            var round = Math.Round(calc, 2);
            return round;
        }

        public double CalculatePerimeter()
        {
            var calc = 2 * Math.PI * this.Radius;
            var round = Math.Round(calc, 2);
            return round;
        }

        public override string ToString()
        {
            return $"Shape: {this.GetType().Name}, Area: {CalculateArea()}, Perimeter: {CalculatePerimeter()}";
        }
    }
}