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
            return $"00{_scoreTeamA}:00{_scoreTeamB}";
        }
    }
}