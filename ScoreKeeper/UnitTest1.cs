using FluentAssertions;
using NUnit.Framework;

namespace ScoreKeeper
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ScoreKeeper_ShouldIncreaseScoreByOneForTeamA_WhenCallMethodScoreTeamA1()
        {
            var scoreKeeper = new ScoreKeeper();
            
            scoreKeeper.ScoreTeamA1();

            string scoreResult = scoreKeeper.GetScore();
            scoreResult.Should().Be("001:000");
        }

        [Test]
        public void ScoreKeeper_GetScore_ShouldReturnEmptyScoreWhenCreated()
        {
            var scoreKeeper = new ScoreKeeper();

            string scoreResult = scoreKeeper.GetScore();

            scoreResult.Should().Be("000:000");
        }
    }
}