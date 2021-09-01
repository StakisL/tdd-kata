using FluentAssertions;
using NUnit.Framework;

namespace TTD
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void StringCalcShouldAddTwoNumbersWhenTwoNumbersPassedWithComma()
        {
            //arrange
            var calc = new StringCalculator();
            
            //act
            var i = calc.Add("1,2");
            
            //assert
            i.Should().Be(3);
        }
    }
}