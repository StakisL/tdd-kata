using System;

namespace GameOfLifeKata
{
    public class Universe
    {
        private readonly int _width = 10;
        private readonly int _height = 10;
        private bool[,] _generation;
        
        public Universe(){}
        public Universe(int width, int height)
        {
            _width = width;
            _height = height;
            _generation = new bool[_width, _height];
        }

        public int GetField() => _width * _height;

        public void SetFirstGeneration(bool[,] generation)
        {
            if (!IsGenerationAlive(generation))
            {
                throw new ArgumentException();
            }

            _generation = generation;
        }

        private static bool IsGenerationAlive(bool[,] generation)
        {
            for (var i = 0; i < generation.GetLength(0); i++)
                for (var j = 0; j < generation.GetLength(1); j++)
                    if (generation[i, j])
                        return true;
            return false;
        }
    }
}