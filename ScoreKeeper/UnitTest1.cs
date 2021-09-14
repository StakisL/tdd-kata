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
        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        public void ScoreKeeper_GetScore_ShouldAlwaysReturnSevenCharacters(int scoreIterationNumbers)
        {
            for (var i = 0; i < scoreIterationNumbers; i++)
            {
                _scoreKeeper.ScoreTeamA1();
            }
            
            var scoreResult = _scoreKeeper.GetScore();

            scoreResult.Length.Should().Be(7);
        }

        [Test]
        public void ScoreKeeper_ScoreTeamB1_ShouldIncreaseScoreTeamBByOne()
        {
            _scoreKeeper.ScoreTeamB1();

            var scoreResult = _scoreKeeper.GetScore();

            scoreResult.Should().Be("000:001");
        }
    }
}