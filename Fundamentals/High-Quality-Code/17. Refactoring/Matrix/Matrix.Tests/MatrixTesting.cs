namespace Matrix.Tests
{
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MatrixTesting
    {
        [TestMethod]
        public void Output_Input1_ReturnExpectedResuslt()
        {
            int[,] expectedOutput =
            {
                {1}
            };

            var walkInMatrix = new WalkInMatrix(1);
            var actualOutput = walkInMatrix.Run();

            var expected = OutputAsString(expectedOutput);
            var actual = OutputAsString(actualOutput);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Output_Input3_ReturnExpectedResuslt()
        {
            int[,] expectedOutput =
            {
                {1, 7, 8},
                {6, 2, 9},
                {5, 4, 3}
            };

            var walkInMatrix = new WalkInMatrix(3);
            var actualOutput = walkInMatrix.Run();

            var expected = OutputAsString(expectedOutput);
            var actual = OutputAsString(actualOutput);

            Assert.AreEqual(expected, actual);
        }

        private static string OutputAsString(int[,] matrix)
        {
            var stringBuilder = new StringBuilder();

            foreach (var re in matrix)
            {
                stringBuilder.Append(re);
            }
            return stringBuilder.ToString();
        }
    }
}
