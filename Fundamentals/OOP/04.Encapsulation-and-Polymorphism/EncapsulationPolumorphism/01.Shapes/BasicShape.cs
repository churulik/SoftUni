using System;
using _01.Shapes.Interfaces;

namespace _01.Shapes
{
    public abstract class BasicShape : IShape
    {
        private double width;
        private double height;
        private double side;

        protected double Width
        {
            get { return this.width; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The widht cannot be negative.");
                }
                this.width = value;
            }
        }

        protected double Height
        {
            get { return this.height; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The height cannot be negative.");
                }
                this.height = value;
            }
        }

        protected double Side
        {
            get { return this.side; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The side cannot be negative.");
                }
                this.side = value;
            }
        }

        public abstract double CalculateArea();


        public abstract double CalculatePerimeter();

        public override string ToString()
        {
            return $"Shape: {this.GetType().Name}, Area: {CalculateArea()}, Perimeter: {CalculatePerimeter()}";
        }
    }
}