using System;
using FluentAssertions;
using NUnit.Framework;

namespace GameOfLifeKata
{
    public class Tests
    {
        private Universe _universe;
        
        [SetUp]
        public void Setup()
        {
            _universe = new Universe();
        }

        [Test]
        public void WhenUniverseCreate_ThenUniverseCreated()
        {
            _universe.Should().NotBeNull();
        }

        [Test]
        public void WhenUniverseWithConcreteParams_ThenGetFieldReturnFieldSizeWithConcreteParams()
        { 
            var generation = new bool[10, 10];
            generation[0, 0] = true;
            
            _universe.SetFirstGeneration(generation);
            var size = _universe.GetField();

            size.Should().Be(10 * 10);
        }

        [Test]
        public void WhenSetStartGenerationCalledWithOnlyDeadCells_ThenMethodShouldThrowException()
        {
            var generation = new bool[10, 10];

            Assert.Throws<ArgumentException>(() => _universe.SetFirstGeneration(generation));
        }
    }
}