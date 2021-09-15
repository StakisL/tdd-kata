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
            var scoreTeamA = GetScoreForTeam(_scoreTeamA);
            var scoreTeamB = GetScoreForTeam(_scoreTeamB);

            return $"{scoreTeamA}:{scoreTeamB}";
        }

        public void ScoreTeamB1()
        {
            _scoreTeamB++;
        }

        private string GetScoreForTeam(int scoreTeam)
        {
            var digitsInScoreTeamA = scoreTeam == 0 ? 0 : Math.Floor(Math.Log10(scoreTeam) + 1);

            return digitsInScoreTeamA switch
            {
                0 => "000",
                1 => $"00{scoreTeam}",
                2 => $"0{scoreTeam}",
                3 => $"{scoreTeam}",
                _ => "999"
            };
        }

        public void ScoreTeamB2()
        {
            _scoreTeamB += 2;
        }

        public void ScoreTeamB3()
        {
            _scoreTeamB += 3;
        }
    }
}