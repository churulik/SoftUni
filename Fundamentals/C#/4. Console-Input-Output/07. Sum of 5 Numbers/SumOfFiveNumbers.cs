using System;

    class SumOfFiveNumbers
    {
        static void Main()
        {
            Console.Write("Enter 5 numbers separated by space: ");            
            string fiveNumbers = Console.ReadLine();
            string[] fiveNumbersSplit = fiveNumbers.Split();
            double number;
            double sum = 0;
            foreach (string numbers in fiveNumbersSplit)
            {
                number = double.Parse(numbers);
                sum = sum + number;
            }
            Console.WriteLine("The sum of the five numbers is {0}", sum);            
        }
    }

