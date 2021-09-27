namespace GameOfLifeKata
{
    public class Universe
    {
        private readonly int _width = 10;
        private readonly int _height = 10;
        
        public Universe(){}
        public Universe(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public int GetField() => _width * _height;
    }
}