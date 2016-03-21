using System;

namespace _02.FractionCalculator
{
    public struct Fraction
    {
        private long denominator;

        public Fraction(long numerator, long denominator) : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }


        public long Numerator { get; set; }

        public long Denominator
        {
            get { return this.denominator; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentOutOfRangeException("The denominator cannot be 0");
                }
                this.denominator = value;
            }
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            var nominator = f1.Numerator * f2.Denominator + f1.Denominator * f2.Numerator;
            var denominator = f1.Denominator * f2.Denominator;
            var result = new Fraction(nominator, denominator);
            return result;
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            var nominator = f1.Numerator * f2.Denominator - f1.Denominator * f2.Numerator;
            var denominator = f1.Denominator * f2.Denominator;
            var result = new Fraction(nominator, denominator);
            return result;
        }

        public override string ToString()
        {
            var output = (decimal) this.Numerator / this.Denominator;
            return $"{output}";
        }
    }
}