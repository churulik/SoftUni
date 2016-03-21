using System;

namespace ConsoleApplication1
{
    class MatrixCalculator
    {
        static void Main()
        {
            var matrixA = new double[,] { { 1, 3 }, { 5, 7 } };
            var matrixB = new double[,] { { 4, 2 }, { 1, 5 } };

            var calculateMatricesResult = TwoDimensionalCalculatorForMatrices(matrixA, matrixB);

            for (int row = 0; row < calculateMatricesResult.GetLength(0); row++)
            {
                for (int column = 0; column < calculateMatricesResult.GetLength(1); column++)
                {
                    Console.Write(calculateMatricesResult[row, column] + " ");
                }
                Console.WriteLine();
            }
        }

        static double[,] TwoDimensionalCalculatorForMatrices(double[,] matrixA, double[,] matrixB)
        {
            
            var matrixAColumnLength = matrixA.GetLength(1);
            var matrixBRowLength = matrixB.GetLength(0);

            if (matrixAColumnLength != matrixBRowLength)
            {
                throw new ArgumentOutOfRangeException(nameof(matrixAColumnLength), "Error! The matrices should have the same lenght.");
            }

            var matrixARowLength = matrixA.GetLength(0);
            var matrixBColumnLength = matrixB.GetLength(1);

            var result = new double[matrixARowLength, matrixBColumnLength];

            var resultRow = result.GetLength(0);
            var resultColumn = result.GetLength(1);

            for (int row = 0; row < resultRow; row++)
            {
                for (int column = 0; column < resultColumn; column++)
                {
                    for (int variable = 0; variable < matrixAColumnLength; variable++)
                    {
                        var matrixACurrentDimension = matrixA[row, variable];
                        var matrixBCurrentDimension = matrixB[variable, column];

                        var sumMatrixAMatrixB = matrixACurrentDimension * matrixBCurrentDimension;

                        result[row, column] += sumMatrixAMatrixB;
                    }
                }
            }

            return result;
        }
    }
}