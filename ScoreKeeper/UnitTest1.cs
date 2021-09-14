using FluentAssertions;
using NUnit.Framework;

namespace ScoreKeeper
{
    public class Tests
    {
        private ScoreKeeper _scoreKeeper; 
            
        [SetUp]
        public void Setup()
        {
            _scoreKeeper = new ScoreKeeper();
        }

        [Test]
        public void ScoreKeeper_ShouldIncreaseScoreByOneForTeamA_WhenCallMethodScoreTeamA1()
        {
            var expectedScore = "001:000";

            _scoreKeeper.ScoreTeamA1();

            var scoreResult = _scoreKeeper.GetScore();
            scoreResult.Should().Be(expectedScore);
        }

        [Test]
        public void ScoreKeeper_GetScore_ShouldReturnEmptyScoreWhenCreated()
        {
            var expectedScore = "000:000";

            var scoreResult = _scoreKeeper.GetScore();
            
            scoreResult.Should().Be(expectedScore);
        }

        [Test]
        public void ScoreKeeper_GetScore_ShouldAlwaysReturnSevenCharacters()
        {
        }
    }
}