namespace Matrix.Writer
{
    using System;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void Write(string result)
        {
            Console.Write(result);
        }
    }
}