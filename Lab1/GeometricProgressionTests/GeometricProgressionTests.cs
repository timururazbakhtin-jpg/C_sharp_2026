using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GeometricProgressionApp;

namespace GeometricProgressionTests
{
    [TestClass]
    public class GeometricProgressionTests
    {
        [TestMethod]
        public void Add_SameRatios_ReturnsSumProgression()
        {
            var prog1 = new GeometricProgression(2, 3);
            var prog2 = new GeometricProgression(5, 3);
            var expected = new GeometricProgression(7, 3);

            var result = prog1.Add(prog2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Add_DifferentRatios_ThrowsArgumentException()
        {
            var prog1 = new GeometricProgression(2, 3);
            var prog2 = new GeometricProgression(5, 4);

            try
            {
                prog1.Add(prog2);
                Assert.Fail("Очікувався виняток ArgumentException, але його не було.");
            }
            catch (ArgumentException)
            {
                // Тест успішно пройдено, виняток спіймано
            }
        }

        [TestMethod]
        public void Subtract_SameRatios_ReturnsDifferenceProgression()
        {
            var prog1 = new GeometricProgression(10, 2);
            var prog2 = new GeometricProgression(3, 2);
            var expected = new GeometricProgression(7, 2);

            var result = prog1.Subtract(prog2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Subtract_DifferentRatios_ThrowsArgumentException()
        {
            var prog1 = new GeometricProgression(10, 2);
            var prog2 = new GeometricProgression(3, -2);

            try
            {
                prog1.Subtract(prog2);
                Assert.Fail("Очікувався виняток ArgumentException, але його не було.");
            }
            catch (ArgumentException)
            {
                // Тест успішно пройдено
            }
        }

        [TestMethod]
        public void Multiply_ByPositiveNumber_ReturnsScaledProgression()
        {
            var prog = new GeometricProgression(3, 2);
            var multiplier = 4.0;
            var expected = new GeometricProgression(12, 2);

            var result = prog.Multiply(multiplier);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Multiply_ByZero_ReturnsZeroProgression()
        {
            var prog = new GeometricProgression(5, 4);
            var multiplier = 0.0;
            var expected = new GeometricProgression(0, 4);

            var result = prog.Multiply(multiplier);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Multiply_ByNegativeNumber_ReturnsScaledProgression()
        {
            var prog = new GeometricProgression(2, 3);
            var multiplier = -2.0;
            var expected = new GeometricProgression(-4, 3);

            var result = prog.Multiply(multiplier);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetSum_NormalConditions_ReturnsCorrectSum()
        {
            var prog = new GeometricProgression(2, 3);
            var n = 3;
            var expected = 26.0; 

            var result = prog.GetSum(n);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetSum_RatioIsOne_ReturnsSumOfEqualElements()
        {
            var prog = new GeometricProgression(5, 1);
            var n = 4;
            var expected = 20.0; 

            var result = prog.GetSum(n);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetSum_ZeroOrNegativeElements_ThrowsArgumentOutOfRangeException()
        {
            var prog = new GeometricProgression(2, 3);
            var n = 0;

            try
            {
                prog.GetSum(n);
                Assert.Fail("Очікувався виняток ArgumentOutOfRangeException.");
            }
            catch (ArgumentOutOfRangeException)
            {
                // Тест успішно пройдено
            }
        }

        [TestMethod]
        public void GetElement_ValidIndex_ReturnsCorrectElement()
        {
            var prog = new GeometricProgression(2, 3);
            var n = 4;
            var expected = 54.0; // 2 * 3^(4-1) = 2 * 27

            var result = prog.GetElement(n);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetElement_ZeroOrNegativeIndex_ThrowsArgumentOutOfRangeException()
        {
            var prog = new GeometricProgression(2, 3);
            var n = -1;

            try
            {
                prog.GetElement(n);
                Assert.Fail("Очікувався виняток ArgumentOutOfRangeException.");
            }
            catch (ArgumentOutOfRangeException)
            {
                // Тест успішно пройдено
            }
        }
    }
}