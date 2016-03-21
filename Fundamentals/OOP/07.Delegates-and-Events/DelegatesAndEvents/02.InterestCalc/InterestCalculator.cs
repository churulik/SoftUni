using System;

namespace _02.InterestCalc
{
    public static class InterestCalculator
    {
        public delegate void CalculateInterest(double sum, double interest, double years);

        public static void GetSimpleInterest(double sum, double interest, double years)
        {
            var calc = sum * (1 + (interest / 100) * years);
            Console.WriteLine("Simple: {0:0.0000}", calc);
        }

        public static void GetCompoundInterest(double sum, double interest, double years)
        {
            var calc = sum * Math.Pow((1 + (interest / 100) / 12), years * 12);
            Console.WriteLine("Compound: {0:0.0000}", calc);
        }
    }
}