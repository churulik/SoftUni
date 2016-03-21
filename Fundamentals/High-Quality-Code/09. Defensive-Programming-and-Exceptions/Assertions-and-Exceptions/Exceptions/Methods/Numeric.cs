namespace Exceptions.Methods
{
    using System;

    public class Numeric
    {
        public static bool IsPrime(int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(number), $"{number} is invalid number. A prime number cannot be negative.");
            }
            if (number == 0 || number == 1)
            {
                return false;
            }

            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}