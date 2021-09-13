using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace ChristmasLightKata
{
    public class LightsGrid
    {
        private readonly int[,] _grid;
        
        public LightsGrid(int rows, int columns)
        {
            _grid = new int[rows, columns];
        }

        public int[,] GetGrid()
        {
            return _grid.Clone() as int[,];
        }

        public void TurnOnAll()
        {
            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                for (int j = 0; j < _grid.GetLength(1); j++)
                {
                    _grid[i, j] += 1;
                }
            }
        }

        public int ToggleLightAtPosition(int row, int column)
        {
            _grid[row, column] += 2;
            return _grid[row, column];
        }

        public List<int> GetGridRow(int row)
        {
            var gridRow = new List<int>();

            for (int column = 0; column < _grid.GetLength(0); column++)
            {
                gridRow.Add(_grid[row,column]);
            }

            return gridRow;
        }

        public void TurnOffRange(int rowSource, int columnSource, int rowDestination, int columnDestination)
        {
            for (int i = rowSource; i <= rowDestination; i++)
            {
                for (int j = columnSource; j <= columnDestination; j++)
                {
                    if (_grid[i, j] >= 1)
                    {
                        _grid[i, j]--;
                    }
                }
            }
        }
        
        public void TurnOnRange(int rowSource, int columnSource, int rowDestination, int columnDestination)
        {
            for (int i = rowSource; i <= rowDestination; i++)
            {
                for (int j = columnSource; j <= columnDestination; j++)
                {
                    _grid[i, j]++;
                }
            }
        }

        public int GetTotalBrightness()
        {
            var sum = 0;
            
            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                for (int j = 0; i < _grid.GetLength(1); i++)
                {
                    sum += _grid[i, j];
                }
            }

            return sum;
        }
    }
}