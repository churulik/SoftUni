using System;

namespace _02.EnterNumbers
{
    class Application
    {
        static void Main()
        {
            var min = 1;
            const int max = 100;

            Console.WriteLine("Enter 10 numbers: ");
            for (int i = 0; i < 10;)
            {
                var tempNum = min;
                min = ReadNumber.Numbers(min, max);
                var minDifference = 10 - i;

                if ((max - min) < minDifference)
                {
                    Console.WriteLine("The diffrence between the numbers should be at least " + minDifference);
                    min = tempNum;
                }
                else if (tempNum < min)
                {
                    switch (i)
                    {
                        case 0:
                            Console.WriteLine("Enter 9 more valid numbers.");
                            break;
                        case 1:
                            Console.WriteLine("Enter 8 more valid numbers.");
                            break;
                        case 2:
                            Console.WriteLine("Enter 7 more valid numbers.");
                            break;
                        case 3:
                            Console.WriteLine("Enter 6 more valid numbers.");
                            break;
                        case 4:
                            Console.WriteLine("Yupiiii!!! 5 more valid numbers left!");
                            break;
                        case 5:
                            Console.WriteLine("Enter 4 more valid numbers.");
                            break;
                        case 6:
                            Console.WriteLine("Enter 3 more valid numbers.");
                            break;
                        case 7:
                            Console.WriteLine("Enter 2 more valid numbers.");
                            break;
                        case 8:
                            Console.WriteLine("Yohooo!!! Enter 1 more valid number.");
                            break;
                    }
                    i++;
                }
            }
            Console.WriteLine("Great game!");
        }
    }
}
