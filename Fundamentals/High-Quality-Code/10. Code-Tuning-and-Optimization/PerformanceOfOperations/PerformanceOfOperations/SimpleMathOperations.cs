using System;
using System.Linq;

namespace PerformanceOfOperations
{
    public class SimpleMathOperations
    {
        private static int intValue;
        private static long longValue;
        private static float floatValue;
        private static double doubleValue;
        private static decimal decimalValue;

        public static void Add(int numberOfTimes)
        {
            Console.WriteLine("Add - int:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    intValue += 1;
                }
            });

            Console.WriteLine("Add - long:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    longValue += 1;
                }
            });

            Console.WriteLine("Add - float:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    floatValue += 1;
                }
            });

            Console.WriteLine("Add - double:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    doubleValue += 1;
                }
            });

            Console.WriteLine("Add - decimal:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    decimalValue += 1;
                }
            });
            Console.WriteLine();
        }

        public static void Subtract(int numberOfTimes)
        {
            Console.WriteLine("Subtract - int:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    intValue -= 1;
                }
            });

            Console.WriteLine("Subtract - long:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    longValue -= 1;
                }
            });

            Console.WriteLine("Subtract - float:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    floatValue -= 1;
                }
            });

            Console.WriteLine("Subtract - double:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    doubleValue -= 1;
                }
            });

            Console.WriteLine("Subtract - decimal:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    decimalValue -= 1;
                }
            });

            Console.WriteLine();
        }

        public static void IncrementPrefix(int numberOfTimes)
        {
            Console.WriteLine("Increment prefix - int:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    ++intValue;
                }
            });

            Console.WriteLine("Increment prefix - long:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    ++longValue;
                }
            });

            Console.WriteLine("Increment prefix - float:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    ++floatValue;
                }
            });

            Console.WriteLine("Increment prefix - double:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    ++doubleValue;
                }
            });

            Console.WriteLine("Increment prefix - decimal:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    ++decimalValue;
                }
            });
            Console.WriteLine();
        }

        public static void IncrementPostfix(int numberOfTimes)
        {
            Console.WriteLine("Increment postfix - int:");
            Timer.DisplayExecutionTime(() =>
            {
                int increment = 0;
                for (int i = 0; i < numberOfTimes; i++)
                {
                    increment++;
                }
            });

            Console.WriteLine("Increment postfix - long:");
            Timer.DisplayExecutionTime(() =>
            {
                long increment = 0;
                for (int i = 0; i < numberOfTimes; i++)
                {
                    increment++;
                }
            });

            Console.WriteLine("Increment postfix - float:");
            Timer.DisplayExecutionTime(() =>
            {
                float increment = 0;
                for (int i = 0; i < numberOfTimes; i++)
                {
                    increment++;
                }
            });

            Console.WriteLine("Increment postfix - double:");
            Timer.DisplayExecutionTime(() =>
            {
                double increment = 0;
                for (int i = 0; i < numberOfTimes; i++)
                {
                    increment++;
                }
            });

            Console.WriteLine("Increment postfix - decimal:");
            Timer.DisplayExecutionTime(() =>
            {
                decimal increment = 0;
                for (int i = 0; i < numberOfTimes; i++)
                {
                    increment++;
                }
            });
            Console.WriteLine();
        }

        public static void Multiply(int numberOfTimes)
        {
            Console.WriteLine("Multiply - int:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    intValue *= 1;
                }
            });

            Console.WriteLine("Multiply - long:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    longValue *= 1;
                }
            });

            Console.WriteLine("Multiply - float:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    floatValue *= 1;
                }
            });

            Console.WriteLine("Multiply - double:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    doubleValue *= 1;
                }
            });

            Console.WriteLine("Multiply - decimal:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    decimalValue *= 1;
                }
            });
            Console.WriteLine();
        }

        public static void Divide(int numberOfTimes)
        {
            Console.WriteLine("Divide - int:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    intValue /= 1;
                }
            });

            Console.WriteLine("Divide - long:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    longValue /= 1;
                }
            });

            Console.WriteLine("Divide - float:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    floatValue /= 1;
                }
            });

            Console.WriteLine("Divide - double:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    doubleValue /= 1;
                }
            });

            Console.WriteLine("Divide - decimal:");
            Timer.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < numberOfTimes; i++)
                {
                    decimalValue /= 1;
                }
            });
            Console.WriteLine();
        }
    }
}