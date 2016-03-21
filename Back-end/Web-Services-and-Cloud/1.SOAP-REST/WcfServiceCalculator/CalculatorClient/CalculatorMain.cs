using System;

namespace CalculatorClient
{
    class CalculatorMain
    {
        static void Main()
        {
            var calculator = new ServiceReferenceCalculator.ServiceCalculatorClient();
            var result = calculator.CalcDistance(10, 10, 15, 15);
            Console.WriteLine(result);
        }
    }
}
