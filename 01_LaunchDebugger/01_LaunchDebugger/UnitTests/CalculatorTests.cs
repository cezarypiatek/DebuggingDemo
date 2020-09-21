using System;
using LibraryNetStandard;
using NUnit.Framework;

namespace UnitTests
{
    public class CalculatorTests
    {
        [Test]
        public static void should_calculate_sum_of_two_numbers()
        {
            //ARRANGE
            var a = 3;
            var b = 4;

            //ACT
            var result = Calculator.Sum(a, b);

            //ASSERT
            Assert.AreEqual(7, result);
        }
    }
}
