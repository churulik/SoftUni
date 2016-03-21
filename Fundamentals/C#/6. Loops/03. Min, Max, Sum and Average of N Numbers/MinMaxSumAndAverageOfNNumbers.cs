using System;

class MinMaxSumAndAverageOfNNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter an integer number: ");
        int n = int.Parse(Console.ReadLine());
        int[]nums = new int[n];
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter another integer: ");
            nums [i] = int.Parse(Console.ReadLine());
            sum += nums[i];
        }
        int min = nums[0];
        int max = nums[0];
        for (int i = 0; i < n; i++)
        {
            if (min > nums[i])
            {
                min = nums[i];
            }
            if (max < nums[i])
            {
                max = nums[i];
            }    
        }      
        Console.WriteLine("min = {0}", min);
        Console.WriteLine("max = {0}", max);
        Console.WriteLine("sum = {0}", sum);
        Console.WriteLine("avr = {0:F2}", (double) sum/n);
    }
}
