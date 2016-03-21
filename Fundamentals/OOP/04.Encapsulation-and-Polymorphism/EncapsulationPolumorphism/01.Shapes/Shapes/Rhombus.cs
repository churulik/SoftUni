using System;

namespace _01.Shapes.Shapes
{
    public class Rhombus : BasicShape
    {
        private double diagonalA;
        private double diagonalB;

        public Rhombus(double side, double diagonalA, double diagonalB)
        {
            this.Side = side;
            this.DiagonalA = diagonalA;
            this.DiagonalB = diagonalB;
        }

        protected double DiagonalA
        {
            get { return this.diagonalA; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The diagonal cannot be negative.");
                }
                this.diagonalA = value;
            }
        }

        protected double DiagonalB
        {
            get { return this.diagonalB; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The diagonal cannot be negative.");
                }
                this.diagonalB = value;
            }
        }

        public override double CalculateArea()
        {
            return (this.DiagonalA * this.DiagonalB) / 2;
        }

        public override double CalculatePerimeter()
        {
            return 4 * this.Side;
        }
    }
}