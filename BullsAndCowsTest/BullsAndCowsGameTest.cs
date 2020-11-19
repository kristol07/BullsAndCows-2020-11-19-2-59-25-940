using BullsAndCows;
using Xunit;

namespace BullsAndCowsTest
{
    public class BullsAndCowsGameTest
    {
        [Fact]
        public void Should_create_BullsAndCowsGame()
        {
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            Assert.NotNull(game);
            Assert.True(game.CanContinue);
        }

        [Fact]
        public void Should_return_0A0B_when_all_digit_and_position_wrong()
        {
            //given
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);

            //when
            string answer = game.Judge("5 6 7 8");

            //then
            Assert.Equal("0A0B", answer);
        }

        [Fact]
        public void Should_return_4A0B_when_all_digit_and_position_correct()
        {
            //given
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);

            //when
            string answer = game.Judge("1 2 3 4");

            //then
            Assert.Equal("4A0B", answer);
        }

        [Theory]
        [InlineData("4 3 1 2")]
        [InlineData("4 3 2 1")]
        public void Should_return_0A4B_when_all_digit_correct_and_all_position_wrong(string guess)
        {
            //given
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);

            //when
            string answer = game.Judge(guess);

            //then
            Assert.Equal("0A4B", answer);
        }
    }

    public class TestSecretGenerator : SecretGenerator
    {
        public override string GenerateSecret()
        {
            return "1234";
        }
    }
}
