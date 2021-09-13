using System.Collections.Generic;

namespace ChristmasLightKata
{
    public class LightsGrid
    {
        private readonly bool[,] _grid;
        
        public LightsGrid(int rows, int columns)
        {
            _grid = new bool[rows, columns];
        }

        public bool[,] GetGrid()
        {
            return _grid.Clone() as bool[,];
        }

        public void TurnOnAll()
        {
            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                for (int j = 0; j < _grid.GetLength(1); j++)
                {
                    _grid[i, j] = true;
                }
            }
        }

        public bool ToggleLightAtPosition(int row, int column)
        {
            _grid[row, column] = !_grid[row, column];
            return _grid[row, column];
        }

        public List<bool> GetGridRow(int row)
        {
            var gridRow = new List<bool>();

            for (int column = 0; column < _grid.GetLength(0); column++)
            {
                gridRow.Add(_grid[row,column]);
            }

            return gridRow;
        }

        public void TurnOffRange(int rowSource, int columnSource, int rowDestination, int columnDestination)
        {
            for (int i = rowSource; i < rowDestination; i++)
            {
                for (int j = columnSource; j < columnDestination; j++)
                {
                    _grid[i, j] = false;
                }
            }
        }
    }
}