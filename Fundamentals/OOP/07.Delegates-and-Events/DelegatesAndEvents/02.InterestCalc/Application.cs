using System;

namespace _02.InterestCalc
{
    class Application
    {
        static void Main()
        {
            InterestCalculator.CalculateInterest simple = InterestCalculator.GetSimpleInterest;
            simple(2500, 7.2, 15);

            InterestCalculator.CalculateInterest compound = InterestCalculator.GetCompoundInterest;
            compound(500, 5.6, 10);
        }
    }
}
