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
            return _grid;
        }
    }
}