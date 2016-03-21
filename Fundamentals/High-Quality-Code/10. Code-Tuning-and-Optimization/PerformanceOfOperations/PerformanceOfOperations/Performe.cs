namespace PerformanceOfOperations
{
    internal class Performe
    {
        private static void Main()
        {
            const int numberOfTimes = 100;

            SimpleMathOperations.Add(numberOfTimes);
            SimpleMathOperations.Subtract(numberOfTimes);
            SimpleMathOperations.IncrementPrefix(numberOfTimes);
            SimpleMathOperations.IncrementPostfix(numberOfTimes);
            SimpleMathOperations.Multiply(numberOfTimes);
            SimpleMathOperations.Divide(numberOfTimes);
            
            ComplexMathOperations.Sqrt(numberOfTimes);
            ComplexMathOperations.Log(numberOfTimes);
            ComplexMathOperations.Sin(numberOfTimes);
        }
    }
}
