using FluentAssertions;
using NUnit.Framework;

namespace ChristmasLightKata
{
    public class Tests
    {
        private LightsGrid _lightGrid;
        
        [SetUp]
        public void Setup()
        {
            _lightGrid = new LightsGrid(1000, 1000);
        }

        [Test]
        public void LightGridsShouldBeExists()
        {
            var grid = _lightGrid.GetGrid();

            grid.Should().NotBeNull();
        }

        [Test]
        public void LightGridTurnOnShouldReturnTurnedOnGrid()
        {
            //act
            _lightGrid.TurnOnAll();

            //assert
            var grid = _lightGrid.GetGrid();

            foreach (var light in grid)
            {
                light.Should().BeTrue();
            }
        }

        [Test]
        public void LightGridGetGridReturnPrivateCloneGrid()
        {
            //arrange
            _lightGrid.TurnOnAll();
            var grid = _lightGrid.GetGrid();

            //act
            grid[0, 1] = false;
            var grid2 = _lightGrid.GetGrid();
            
            //assert
            foreach (var light in grid2)
            {
                light.Should().BeTrue();
            }
        }

        [Test]
        [TestCase(0,0)]
        [TestCase(1, 4)]
        [TestCase(999, 0)]
        public void WhenToggleLightAtPositionThenLightToggled(int row, int column)
        {
            var grid = _lightGrid.GetGrid();
            var light = grid[row, column];
            
            var toggledLight =  _lightGrid.ToggleLightAtPosition(row, column);

            toggledLight.Should().NotBe(light);
        }

        [Test]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(13)]
        public void GetGridRowShouldReturnRow(int row)
        {
            _lightGrid.ToggleLightAtPosition(0, 10);
            _lightGrid.ToggleLightAtPosition(13, 0);
            
            var grid = _lightGrid.GetGrid();

            var gridRow = _lightGrid.GetGridRow(row);

            gridRow.Count.Should().Be(grid.GetLength(0));
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                gridRow[i].Should().Be(grid[row, i], $"Grid value at position {i} unexpected");
            }
        }

        [Test]
        public void WhenTurnOffGridCenterShouldCenterBeTurnedOff()
        {
            for (int i = 499; i < 500; i++)
            {
                for (int j = 499; j < 500; j++)
                {
                    _lightGrid.ToggleLightAtPosition(i, j);
                }
            }
            
            var grid = _lightGrid.GetGrid();
            
            _lightGrid.TurnOffRange(499,499, 500, 500);

            var changedGrid = _lightGrid.GetGrid();
            
            for (int i = 499; i < 500; i++)
            {
                for (int j = 499; j < 500; j++)
                {
                    changedGrid[i, j].Should().Be(false);
                }
            }
        }
    }
}