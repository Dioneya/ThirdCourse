using NUnit.Framework;
using System;
namespace Test
{
    public class Tests
    {
        
        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FormatExceptionTest()
        {
            LinearEquationsSystem linearSystem = new LinearEquationsSystem();
            double[,] values = new double[2, 4] { { 9,3,4,5 }, { 2,4,3,5 } };
            Assert.Throws<FormatException>(()=>linearSystem.SetCoefficients(values));
        }

        [Test]
        public void ZeroDetExceptionTest() 
        {
            LinearEquationsSystem linearSystem = new LinearEquationsSystem();
            double[,] values = new double[2, 2] { {0,0}, {0,0} };
            Assert.Throws<ArgumentException>(() => linearSystem.SetCoefficients(values));
        }

        [Test]
        public void CorrectCalc2x2Test() 
        {
            double[,] values = new double[2, 2] { { 1, 4 }, { 5, 6 } };
            LinearEquationsSystem linearSystem = new LinearEquationsSystem(values);
            double[] result = new double[2] { 5, 11 };

            Assert.AreEqual(linearSystem.Solve(), result);
        }

        [Test]
        public void CorrectCalc3x3Test()
        {
            double[,] values = new double[3, 3] { { 1, 4, 2 }, { 5, 6, 1}, { 3,0,2} };
            LinearEquationsSystem linearSystem = new LinearEquationsSystem(values);
            double[] result = new double[3] { 7, 12, 5 };

            Assert.AreEqual(linearSystem.Solve(), result);
        }
    }
}