// Refactor the C# code from the Visual Studio Project "Refactoring-Homework.zip" to improve its internal quality. You might follow the following steps:
// 1. Make some initial refactorings like:
// Reformat the code.
// Rename the ugly named variables.
// 2. Make the code testable.
// Think how to test console-based input / output.
// 3. Write unit tests. Fix any bugs found in the mean time.
// 4. Refactor the code following the guidelines from this chapter. Do it step by step. Run the unit tests after each major change.
namespace MatrixWalk
{
    using System;

    public static class MatrixWalk
    {
        public static void Main(string[] args)
        {
            int n = GetMatrixDimensions();
            var matrix = new Matrix(n);
            matrix.GenerateMatrixWalk();
            Console.Write(matrix);
        }

        public static int GetMatrixDimensions()
        {
            Console.WriteLine("Enter a positive integer number:");
            string input = Console.ReadLine();
            int n = 0;
            while (!int.TryParse(input, out n) || n <= 0 || n > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            return n;
        }
    }
}
