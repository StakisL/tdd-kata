using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Ohce
{
    public class Tests
    {
        private DateTime _date;
        private Mock<IDateTimeService> _dateTimeServiceMock;
        
        [SetUp]
        public void Setup()
        {
            _date = DateTime.Now;
            _dateTimeServiceMock = new Mock<IDateTimeService>();
        }

        [Test]
        [TestCase("2020-07-10 21:00:00.000", "¡Buenas noches Staison!")]
        [TestCase("2020-07-10 7:00:00.000", "¡Buenas dias Staison!")]
        [TestCase("2020-07-10 13:00:00.000", "¡Buenas tardes Staison!")]
        public void WhenTimeIsBetweenTwentyAndSixHoursOhce_ShouldGreetGoodNight(string dateTime, string expectedGreet)
        {
            _dateTimeServiceMock.Setup(s => s.GetCurrentDateTime()).Returns(DateTime.Parse(dateTime));

            var ohce = new Ohce(_dateTimeServiceMock.Object);
            var name = "Staison";
            
            var greetText = ohce.Start(name);

            greetText.Should().Be(expectedGreet);
        }

        [Test]
        [TestCase("Hello", "olleH")]
        [TestCase("oto", "oto\n¡Bonita palabra!")]
        [TestCase("stop", "pots")]
        [TestCase("Stop!", "Adios Pedro")]
        public void WhenWeSayHello_HeShouldAnswerOlleh(string word, string expected)
        {
            var ohce = new Ohce(_dateTimeServiceMock.Object);

            var result = ohce.ReverseWord(word);

            result.Should().Be(expected);
        }

        [Test]
        [TestCase("hui", false)]
        [TestCase("huh", true)]
        public void WhenWordIsPalindrome_ThenReturnTrue(string word, bool expectedPalindrome)
        {
            var result = Ohce.IsPalindrome(word);

            result.Should().Be(expectedPalindrome);
        }
    }
}