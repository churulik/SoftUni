namespace Matrix
{
    using System;
    using Writer;

    internal class MatrixMain
    {
        private static void Main()
        {
            var n = ReadInput();
            var walkInMatrix = new WalkInMatrix(n);
            walkInMatrix.Run();
            var writer = new ConsoleWriter();
            walkInMatrix.PrintMatrix(writer);
        }

        private static int ReadInput()
        {
            const int minNumber = 1;
            const int maxNumber = 100;

            Console.WriteLine("Enter a positive number ");
            var input = Console.ReadLine();
            int n;
            while (!int.TryParse(input, out n) || n < minNumber || n > maxNumber)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }
            return n;
        }
    }
}
