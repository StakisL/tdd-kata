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
        [TestCase("//;\n,1;2",3)]
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
        public void StringCalcShouldThrowArgumentExceptionWhenDelimitersUsedIncorrectly()
        {
            //arrange
            var calc = new StringCalculator();
            var testString = "1,\n";
            
            //act & assert
            Assert.Throws<ArgumentException>(() => calc.Add(testString));
        }

        [Test]
        [TestCase("//;\n1;2", ";")]
        [TestCase("///fdsgsdgsd\fdsgdsgd", "/")]
        [TestCase("\n1;2", ";")]
        public void FindDelimiterShouldReturnSemiColumnWhenSemiColumnSetAfterTwoSlashes(string inputString, string result)
        {
            var reg = StringCalculator.FindDelimiter(inputString);

            reg.Should().Be(result);
        }

        [Test]
        public void FindNumberWithDelimiters()
        {
            string input = "//;\n1;2";
            
            var result = Regex.Match(input, "\\\n(.*)");

            result.Groups[1].Value.Should().Be("1;2");
        }
    }
}