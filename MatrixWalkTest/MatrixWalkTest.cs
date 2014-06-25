namespace MatrixWalkTest
{
    using System;
    using System.IO;
    using MatrixWalk;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MatrixWalkTest
    {
        [TestMethod]
        public void TestGetMatrixDimensionsFour()
        {
            StringReader reader = new StringReader("4");
            Console.SetIn(reader);
            Assert.AreEqual(MatrixWalk.GetMatrixDimensions(), 4);
        }

        [TestMethod]
        public void TestGetMatrixDimensionsFirstZeroThenFour()
        {
            StringReader reader = new StringReader("0\n4");
            Console.SetIn(reader);
            Assert.AreEqual(MatrixWalk.GetMatrixDimensions(), 4);
        }

        [TestMethod]
        public void TestGetMatrixDimensionsFirstHundredAndOneThenFour()
        {
            StringReader reader = new StringReader("101\n4");
            Console.SetIn(reader);
            Assert.AreEqual(MatrixWalk.GetMatrixDimensions(), 4);
        }

        [TestMethod]
        public void TestMatrixWalkMain()
        {
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
            StringReader reader = new StringReader("6");
            Console.SetIn(reader);
            MatrixWalk.Main(null);
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
            var actual = writer.ToString().Substring(34);
            Assert.AreEqual(actual, expected);
        }
    }
}
