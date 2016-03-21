namespace Exceptions.Methods
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Extract
    {

        public static string Ending(string str, int count)
        {
            if (count > str.Length)
            {
                throw new IndexOutOfRangeException($"Invalid count! '{str}' does not have {count} chars.");
            }

            StringBuilder result = new StringBuilder();
            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }

        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            if (startIndex < 0)
            {
                throw new IndexOutOfRangeException($"The start index value ({startIndex}) is not valid. The value must be positive.");
            }

            if (count < 0)
            {
                throw new IndexOutOfRangeException($"The count value ({count}) is not valid. The value must be positive.");
            }

            if (startIndex + count > arr.Length)
            {
                throw new IndexOutOfRangeException("Start index value plus count value cannot be greater than array lenght.");
            }

            List<T> result = new List<T>();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }

            return result.ToArray();
        }
    }
}