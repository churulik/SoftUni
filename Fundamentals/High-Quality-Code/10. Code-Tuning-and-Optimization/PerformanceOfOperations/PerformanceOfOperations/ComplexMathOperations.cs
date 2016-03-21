using System;

namespace PerformanceOfOperations
{
    public class ComplexMathOperations
    {
        private static float floatValue;
        private static double doubleValue;
        private static decimal decimalValue;

        public static void Sqrt(int numberOfTimes)
        {
            Console.WriteLine("Square root - float:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    floatValue = floatValue + i;
                    Math.Sqrt(floatValue);
                }
            });

            Console.WriteLine("Square root - double:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    doubleValue = doubleValue + i;
                    Math.Sqrt(doubleValue);
                }
            });

            Console.WriteLine("Square root - decimal:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    double decimaToDouble = (double)(decimalValue + i);
                    Math.Sqrt(decimaToDouble);
                }
            });

            Console.WriteLine();
        }

        public static void Log(int numberOfTimes)
        {
            Console.WriteLine("Natural logarithm - float:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    floatValue = floatValue + i;
                    Math.Log(floatValue);
                }
            });

            Console.WriteLine("Natural logarithm - double:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    doubleValue = doubleValue + i;
                    Math.Log(doubleValue);
                }
            });

            Console.WriteLine("Natural logarithm - decimal:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    double decimaToDouble = (double)(decimalValue + i);
                    Math.Log(decimaToDouble);
                }
            });

            Console.WriteLine();
        }

        public static void Sin(int numberOfTimes)
        {
            Console.WriteLine("Sine - float:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    floatValue = floatValue + i;
                    Math.Sin(floatValue);
                }
            });

            Console.WriteLine("Sine - double:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    doubleValue = doubleValue + i;
                    Math.Sin(doubleValue);
                }
            });

            Console.WriteLine("Sine  - decimal:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    double decimaToDouble = (double)(decimalValue + i);
                    Math.Sin(decimaToDouble);
                }
            });

            Console.WriteLine();
        }
    }
}