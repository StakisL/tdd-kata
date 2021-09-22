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
        public void WhenTimeIsBetweenTwentyAndSixHoursOhce_ShouldGreetGoodNight(string dateTime, string expectedGreet)
        {
            _dateTimeServiceMock.Setup(s => s.GetCurrentDateTime()).Returns(DateTime.Parse(dateTime));

            var ohce = new Ohce(_dateTimeServiceMock.Object);
            var name = "Staison";
            
            var greetText = ohce.Start(name);

            greetText.Should().Be(expectedGreet);
        }
    }
}