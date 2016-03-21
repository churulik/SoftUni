using System;

namespace _01.SquareRoot
{
    class Application
    {
        static void Main()
        {
            try
            {
                Console.Write("Enter a number: ");
                var number = Convert.ToDouble(Console.ReadLine());
                var square = Math.Sqrt(number);
                try
                {
                    if (number < 0)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    Console.Write("The squere root of the number is: " + square);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.Write("The number cannot be negative");
                }

            }
            catch (FormatException)
            {

                Console.Write("The input has to be a number");
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                Console.WriteLine(" :)");
            }
        }
    }
}
