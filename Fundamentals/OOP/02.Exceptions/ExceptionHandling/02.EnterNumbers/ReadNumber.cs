using System;

namespace _02.EnterNumbers
{
    public class ReadNumber
    {
        public static int Numbers(int start, int end)
        {
            var number = start;
            try
            {
                number = Convert.ToInt32(Console.ReadLine());

                try
                {
                    if (number <= start)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                catch (ArgumentOutOfRangeException)
                {

                    Console.WriteLine("Enter a number bigger than " + start);
                    return start;
                }

                try
                {
                    if (number > end)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Enter a number smaller than " + end);
                    return start;
                }


            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return number;
        }
    }
}