namespace ScoreKeeper
{
    public class ScoreKeeper
    {
        private int _scoreTeamA;
        
        public void ScoreTeamA1()
        {
            _scoreTeamA++;
        }

        public string GetScore()
        {
            return $"00{_scoreTeamA}:000";
        }
    }
}