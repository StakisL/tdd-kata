using System;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace StringCalculator
{
    public class Tests
    {            
        StringCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new StringCalculator();
        }

        [Test]
        [TestCase("1,2", 3)]
        [TestCase("", 0)]
        [TestCase("1",1)]
        [TestCase("1,2,3",6)]
        [TestCase("1\n2,3",6)]
        [TestCase("//;\n1;2",3)]
        [TestCase("2, 1001", 2)]
        [TestCase("1001,1001", 0)]
        [TestCase("//[^^^]\n1^^^2^^^3", 6)]
        [TestCase("//[\n1[2[3", 6)]
        public void ShouldReturnThree_WhenOneAndTwoPassed(string input, int expected)
        {
            int result = _calculator.Add(input);

            result.Should().Be(expected);
        }

        [Test]
        [TestCase("-1,2,3", "-1")]
        [TestCase("-1,-22,3", "-1,-22")]
        [TestCase("-5,-6,-7", "-5,-6,-7")]
        public void Add_ShouldThrowException_WhenNegativeNumberPassed(string input, string expectedResult)
        {
            try
            {
                _calculator.Add(input);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, $"Negatives not allowed: {expectedResult}");
            }
        }
    }
}