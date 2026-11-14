using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TimeLibrary;

namespace TimeTests
{
    [TestClass]
    public class TimeTests
    {
        [TestMethod]
        public void Constructor_ValidParameters_SetsPropertiesCorrectly()
        {
            var time = new Time(14, 35, 50);

            Assert.AreEqual(14, time.Hours);
            Assert.AreEqual(35, time.Minutes);
            Assert.AreEqual(50, time.Seconds);
        }

        [TestMethod]
        public void Constructor_InvalidHours_ThrowsArgumentOutOfRangeException()
        {
            try
            {
                var time = new Time(24, 0, 0);
                Assert.Fail("Очікувався виняток ArgumentOutOfRangeException.");
            }
            catch (ArgumentOutOfRangeException) { }
        }

        [TestMethod]
        public void Subtract_TwoTimes_ReturnsDifferenceInSeconds()
        {
            var t1 = new Time(10, 1, 15);
            var t2 = new Time(9, 0, 0);

            int diff = t1 - t2;

            Assert.AreEqual(3675, diff);
        }

        [TestMethod]
        public void Increment_NormalTime_AddsOneSecond()
        {
            var time = new Time(12, 30, 45);

            time++;

            Assert.AreEqual(new Time(12, 30, 46), time);
        }

        [TestMethod]
        public void Increment_EndOfDay_WrapsAroundToMidnight()
        {
            var time = new Time(23, 59, 59);

            time++;

            Assert.AreEqual(new Time(0, 0, 0), time);
        }

        [TestMethod]
        public void Decrement_NormalTime_SubtractsOneSecond()
        {
            var time = new Time(12, 30, 45);

            time--;

            Assert.AreEqual(new Time(12, 30, 44), time);
        }

        [TestMethod]
        public void Decrement_Midnight_WrapsAroundToEndOfDay()
        {
            var time = new Time(0, 0, 0);

            time--;

            Assert.AreEqual(new Time(23, 59, 59), time);
        }

        [TestMethod]
        public void TrueFalseOperators_MidnightAndNonMidnight_ReturnExpected()
        {
            var midnight = new Time(0, 0, 0);
            var morning = new Time(8, 0, 0);

            bool isMidnightTrue = midnight ? true : false;
            bool isMorningTrue = morning ? true : false;

            Assert.IsFalse(isMidnightTrue);
            Assert.IsTrue(isMorningTrue);
        }

        [TestMethod]
        public void ImplicitCast_TimeToInt_ReturnsTotalSeconds()
        {
            var time = new Time(1, 1, 1);

            int totalSeconds = time;

            Assert.AreEqual(3661, totalSeconds);
        }

        [TestMethod]
        public void ExplicitCast_ValidSecondsToTime_ReturnsTimeObject()
        {
            int totalSeconds = 3661;

            Time time = (Time)totalSeconds;

            Assert.AreEqual(new Time(1, 1, 1), time);
        }

        [TestMethod]
        public void ExplicitCast_SecondsOutOfRange_ThrowsArgumentOutOfRangeException()
        {
            try
            {
                Time time = (Time)86400;
                Assert.Fail("Очікувався виняток ArgumentOutOfRangeException.");
            }
            catch (ArgumentOutOfRangeException) { }
        }

        [TestMethod]
        public void ComparisonOperators_DifferentTimes_ReturnCorrectResults()
        {
            var t1 = new Time(8, 0, 0);
            var t2 = new Time(18, 30, 0);
            var t1Copy = new Time(t1);

            Assert.IsTrue(t1 == t1Copy);
            Assert.IsTrue(t1 != t2);
            Assert.IsTrue(t1 < t2);
            Assert.IsTrue(t2 > t1);
            Assert.IsTrue(t1 <= t1Copy);
            Assert.IsTrue(t2 >= t1);
        }
    }
}
