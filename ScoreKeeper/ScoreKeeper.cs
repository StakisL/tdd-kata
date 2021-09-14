using System;

namespace ScoreKeeper
{
    public class ScoreKeeper
    {
        private int _scoreTeamA;
        private int _scoreTeamB;
        
        public void ScoreTeamA1()
        {
            _scoreTeamA++;
        }

        public string GetScore()
        {
            var digitsInScoreTeamA = _scoreTeamA == 0 ? 0 : Math.Floor(Math.Log10(_scoreTeamA) + 1);

            var scoreTeamA = digitsInScoreTeamA switch
            {
                0 => "000",
                1 => $"00{_scoreTeamA}",
                2 => $"0{_scoreTeamA}",
                3 => $"{_scoreTeamA}",
                _ => "999"
            };

            return $"{scoreTeamA}:00{_scoreTeamB}";
        }

        public void ScoreTeamB1()
        {
            _scoreTeamB++;
        }
    }
}