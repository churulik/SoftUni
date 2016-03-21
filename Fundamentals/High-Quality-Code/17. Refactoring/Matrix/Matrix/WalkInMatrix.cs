namespace Matrix
{
    using System;
    using Writer;

    public class WalkInMatrix
    {
        private const int SecondLastCell = 7;
        private const int PosibleDirections = 8;
        private static int[] rowDirections;
        private static int[] colDirections;
        private readonly int n;
        private readonly int[,] matrix;
        private int currentValue = 1;
        private int row;
        private int col;
        private int directionX = 1;
        private int directionY = 1;

        public WalkInMatrix(int n)
        {
            this.n = n;
            this.matrix = new int[n,n];
        }

        public int[,] Run()
        {

            this.CreateMatrix();

            FindNextCell(this.matrix, ref this.row, ref this.col);

            if (this.row != 0 && this.col != 0)
            {
                this.directionX = 1;
                this.directionY = 1;

                this.CreateMatrix();
            }

            return this.matrix;
        }

        public void PrintMatrix(IWriter writer)
        {
            for (int x = 0; x < this.n; x++)
            {
                for (int y = 0; y < this.n; y++)
                {
                    writer.Write($"{this.matrix[x, y],3}");
                }

                writer.WriteLine();
            }
        }

        private void CreateMatrix()
        {
            while (true)
            {
                this.matrix[this.row, this.col] = this.currentValue;

                if (!CheckValidDirections(this.matrix, this.row, this.col))
                {
                    break;
                }

                while (this.row + this.directionX >= this.n
                       || this.row + this.directionX < 0
                       || this.col + this.directionY >= this.n
                       || this.col + this.directionY < 0
                       || this.matrix[this.row + this.directionX, this.col + this.directionY] != 0)
                {
                    ChangeDirection(ref this.directionX, ref this.directionY);
                }

                this.row += this.directionX;
                this.col += this.directionY;
                this.currentValue++;
            }
        }

        private static void ChangeDirection(ref int row, ref int col)
        {
            Direction(out rowDirections, out colDirections);

            int changeDirection = 0;
            for (int i = 0; i < PosibleDirections; i++)
            {
                if (rowDirections[i] == row && colDirections[i] == col)
                {
                    changeDirection = i;
                    break;
                }
            }

            if (changeDirection == SecondLastCell)
            {
                row = rowDirections[0];
                col = colDirections[0];
                return;
            }

            row = rowDirections[changeDirection + 1];
            col = colDirections[changeDirection + 1];
        }

        private static bool CheckValidDirections(int[,] matrix, int row, int col)
        {
            Direction(out rowDirections, out colDirections);

            for (int i = 0; i < PosibleDirections; i++)
            {
                if (row + rowDirections[i] >= matrix.GetLength(0) || row + rowDirections[i] < 0)
                {
                    rowDirections[i] = 0;
                }

                if (col + colDirections[i] >= matrix.GetLength(0) || col + colDirections[i] < 0)
                {
                    colDirections[i] = 0;
                }
            }

            for (int i = 0; i < PosibleDirections; i++)
            {
                if (matrix[row + rowDirections[i], col + colDirections[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static void FindNextCell(int[,] matrix, ref int row, ref int col)
        {
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(0); y++)
                {
                    if (matrix[x, y] == 0)
                    {
                        row = x;
                        col = y;
                        return;
                    }
                }
            }
        }

        private static void Direction(out int[] x, out int[] y)
        {
            x = new[] { 1, 1, 1, 0, -1, -1, -1, 0 };
            y = new[] { 1, 0, -1, -1, -1, 0, 1, 1 };
        }
    }
}