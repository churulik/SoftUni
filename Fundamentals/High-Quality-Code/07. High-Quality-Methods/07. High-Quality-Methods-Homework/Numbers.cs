using System;

namespace Methods
{
    public static class Numbers
    {
        public static string NumberToItsNumericalName(int number)
        {
            switch (number)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
            }

            return "Invalid number!";
        }

        public static int FindMaxNumber(params int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentNullException(nameof(numbers), "Invalid value.");
            }

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > numbers[0])
                {
                    numbers[0] = numbers[i];
                }
            }

            return numbers[0];
        }

        public static string FormatNumber(double number, string format)
        {
            if (format == "f")
            {
                return $"{number:f2}";
            }
            if (format == "%")
            {
                return $"{number:p0}";
            }
            if (format == "r")
            {
                return $"{number,8}";
            }
            return "Invalid format";
        }
    }
}