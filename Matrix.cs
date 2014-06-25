namespace MatrixWalk
{
    using System;
    using System.Text;

    public class Matrix
    {
        public Matrix(int n)
        {
            if (n < 1 || n > 100)
            {
                throw new ArgumentException("The matrix rows/columns have to be between 1 and 100 inclusive!");
            }

            this.Data = new int[n, n];
        }

        public int[,] Data { get; private set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < this.Data.GetLength(0); i++)
            {
                for (int j = 0; j < this.Data.GetLength(1); j++)
                {
                    int padding = (this.Data.GetLength(0) * this.Data.GetLength(1)).ToString().Length + 1;
                    output.Append(this.Data[i, j].ToString().PadLeft(padding));
                }

                output.AppendLine();
            }

            return output.ToString();
        }

        public void GenerateMatrixWalk()
        {
            int counter = 1,
                row = 0,
                col = 0,
                changeInCol = 1,
                changeInRow = 1, 
                n = this.Data.GetLength(0);

            this.Data[row, col] = counter;
            while (counter <= n * n && this.IsPossibleToMove(row, col))
            {
                do
                {
                    if (this.IsStepPossible(row + changeInRow, col + changeInCol))
                    {
                        row += changeInRow;
                        col += changeInCol;
                        counter++;
                        this.Data[row, col] = counter;
                    }
                    else
                    {
                        this.ChangeDirection(ref changeInRow, ref changeInCol);
                    }
                }
                while (this.IsPossibleToMove(row, col));

                changeInCol = 1;
                changeInRow = 1;
                this.FindFreeCell(out row, out col);
            }
        }

        private void ChangeDirection(ref int dx, ref int dy)
        {
            int[] changeInX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] changeInY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int currentChangeIndex = 0;
            for (int i = 0; i < 8; i++)
            {
                if (changeInX[i] == dx && changeInY[i] == dy)
                {
                    currentChangeIndex = i;
                    break;
                }
            }

            if (currentChangeIndex < 7)
            {
                dx = changeInX[currentChangeIndex + 1];
                dy = changeInY[currentChangeIndex + 1];
            }
            else
            {
                dx = changeInX[0];
                dy = changeInY[0];
            }
        }

        private bool IsPossibleToMove(int x, int y)
        {
            int[] changeInX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] changeInY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            for (int i = 0; i < 8; i++)
            {
                if (x + changeInX[i] >= this.Data.GetLength(0) || x + changeInX[i] < 0)
                {
                    changeInX[i] = 0;
                }

                if (y + changeInY[i] >= this.Data.GetLength(0) || y + changeInY[i] < 0)
                {
                    changeInY[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (this.Data[x + changeInX[i], y + changeInY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private void FindFreeCell(out int currentRow, out int currentCol)
        {
            currentCol = 0;
            currentRow = 0;
            for (int r = 0; r < this.Data.GetLength(0); r++)
            {
                for (int c = 0; c < this.Data.GetLength(1); c++)
                {
                    if (this.Data[r, c] == 0)
                    {
                        currentCol = r;
                        currentRow = c;
                        return;
                    }
                }
            }
        }

        private bool IsStepPossible(int r, int c)
        {
            return r >= 0 && r < this.Data.GetLength(0) && c >= 0 && c < this.Data.GetLength(1) && this.Data[r, c] == 0;
        }
    }
}
