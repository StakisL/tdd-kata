using System;

namespace GameOfLifeKata
{
    public class Universe
    {
        private bool[,] _generation;
        
        public Universe(){}

        public long GetField() => _generation.LongLength;

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