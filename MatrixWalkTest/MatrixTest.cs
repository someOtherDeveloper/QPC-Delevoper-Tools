namespace MatrixWalkTest
{
    using System;
    using MatrixWalk;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        public void TestMatrixConstructorInitializeDataRows()
        {
            int n = 6;
            var matrix = new Matrix(n);
            Assert.AreEqual(n, matrix.Data.GetLength(0));
        }

        [TestMethod]
        public void TestMatrixConstructorInitializeDataColumns()
        {
            int n = 3;
            var matrix = new Matrix(n);
            Assert.AreEqual(n, matrix.Data.GetLength(1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMatrixConstructorInitializeDataUnderOneRows()
        {
            int n = 0;
            var matrix = new Matrix(n);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMatrixConstructorInitializeDataMoreThenHundredRows()
        {
            int n = 101;
            var matrix = new Matrix(n);
        }

        [TestMethod]
        public void TestMatrixToString()
        {
            var matrix = new Matrix(3);
            string expected =
                " 0 0 0" +
                Environment.NewLine +
                " 0 0 0" +
                Environment.NewLine +
                " 0 0 0" +
                Environment.NewLine;
            Assert.AreEqual(matrix.ToString(), expected);
        }

        [TestMethod]
        public void TestMatrixGenerateMatrixWalkNineCell()
        {
            var matrix = new Matrix(3);
            matrix.GenerateMatrixWalk();
            string expected =
                " 1 7 8" +
                Environment.NewLine +
                " 6 2 9" +
                Environment.NewLine +
                " 5 4 3" +
                Environment.NewLine;
            Assert.AreEqual(matrix.ToString(), expected);
        }

        [TestMethod]
        public void TestMatrixGenerateMatrixWalkOneCell()
        {
            var matrix = new Matrix(1);
            matrix.GenerateMatrixWalk();
            string expected = " 1" + Environment.NewLine;
            Assert.AreEqual(matrix.ToString(), expected);
        }

        [TestMethod]
        public void TestMatrixGenerateMatrixWalkThirtySixCell()
        {
            var matrix = new Matrix(6);
            matrix.GenerateMatrixWalk();
            string expected =
                "  1 16 17 18 19 20" +
                Environment.NewLine +
                " 15  2 27 28 29 21" +
                Environment.NewLine +
                " 14 31  3 26 30 22" +
                Environment.NewLine +
                " 13 36 32  4 25 23" +
                Environment.NewLine +
                " 12 35 34 33  5 24" +
                Environment.NewLine +
                " 11 10  9  8  7  6" +
                Environment.NewLine;
            Assert.AreEqual(matrix.ToString(), expected);
        }
    }
}
