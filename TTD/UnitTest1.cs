using System;
using System.Text;
using System.Text.RegularExpressions;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace TTD
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("",0)]
        [TestCase("1,2",3)]
        [TestCase("1,2,3", 6)]
        [TestCase("1,2,3,4,5", 15)]
        [TestCase("1,2\n3",6)]
        public void StringCalcShouldAddTwoNumbersWhenTwoNumbersPassedWithComma(string inputNumbers, int expected)
        {
            //arrange
            var calc = new StringCalculator();
            
            //act
            var i = calc.Add(inputNumbers);
            
            //assert
            i.Should().Be(expected);
        }

        [Test]
        [TestCase("//;\n,1;2")]
        [TestCase("1,\n")]
        public void StringCalcShouldThrowArgumentExceptionWhenDelimitersUsedIncorrectly(string input)
        {
            //arrange
            var calc = new StringCalculator();
            
            //act & assert
            Assert.Throws<ArgumentException>(() => calc.Add(input));
        }

        [Test]
        [TestCase("//;\n1;2", ";")]
        [TestCase("///fdsgsdgsd\fdsgdsgd", "/")]
        [TestCase("\n1;2", ",")]
        public void FindDelimiterShouldReturnSemiColumnWhenSemiColumnSetAfterTwoSlashes(string inputString, string result)
        {
            var reg = StringCalculator.FindDelimiter(inputString);

            reg.Should().Be(result);
        }

        [Test]
        [TestCase("//;\n1;2", "1;2")]
        [TestCase("1;2","1;2")]
        [TestCase("","")]
        [TestCase("1,2\n3","1,2\n3")]
        [TestCase("\n", "\n")]
        public void FindNumberWithDelimiters(string input, string expected)
        {
            var result = StringCalculator.FindNumbers(input);
            result.Should().Be(expected);
        }

        [Test]
        [TestCase("1,2,-3", "negative not allowed: -3")]
        [TestCase("1,2,-3,-4", "negative not allowed: -3, -4")]
        [TestCase("-1,-2,-3", "negative not allowed: -1, -2, -3")]
        public void AddMethodShouldThrowExceptionWhenNegativePassed(string input, string expected)
        {
            var calc = new StringCalculator();

            try
            {
                calc.Add(input);
            }
            catch (Exception e)
            {
                e.GetType().Should().Be<ArgumentException>();
                e.Message.Should().Be(expected);
            }
        }
    }
}