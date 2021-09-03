using BowlingKata;
using Shouldly;
using Xunit;

namespace BowlingKataTests
{
    public class BowlingGameCalculationShould
    {
        [Fact]
        public void InitialScoreShouldBeZero()
        {
            var sut = new Game();

            sut.Score().ShouldBe(0);
        }

        [Fact]
        public void PerfectGame()
        {
            var sut = new Game();
            for (var i = 0; i < 13; i++)
            {
                sut.Roll(10);
            }

            sut.Score().ShouldBe(300);
        }
        
        [Fact]
        public void After20RollsScoreShouldBe20()
        {
            var sut = new Game();

            for (var i = 0; i < 20; i++)
            {
                sut.Roll(1);
            }

            sut.Score().ShouldBe(20);
        }

        [Fact]
        public void After1RollScoreShouldBe1()
        {
            var sut = new Game();

            sut.Roll(1);

            sut.Score().ShouldBe(1);
        }

        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(9)]
        [Theory]
        public void After1RollScoreShouldBeUpdated(int knockedDown)
        {
            var sut = new Game();

            sut.Roll(knockedDown);

            sut.Score().ShouldBe(knockedDown);
        }

        [Fact]
        public void After1StrikeScoreShouldBeUpdatedInNextFrame()
        {
            var sut = new Game();

            //strike
            sut.Roll(10);

            //sut.Score().ShouldBe(0);
            //next frame
            sut.Roll(2);
            sut.Roll(2);

            sut.Score().ShouldBe(18);
        }

        [Fact]
        public void After1SpareScoreShouldBeUpdatedInNextFrame()
        {
            var sut = new Game();

            //spare
            sut.Roll(2);
            sut.Roll(8);

            //sut.Score().ShouldBe(0);
            //next frame
            sut.Roll(2);
            sut.Roll(2);

            sut.Score().ShouldBe(16);
        }
    }
}