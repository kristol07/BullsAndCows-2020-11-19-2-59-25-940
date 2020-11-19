using BullsAndCows;
using Moq;
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

        [Theory]
        [InlineData("5 6 7 8", "1234")]
        [InlineData("1 2 3 4", "5678")]
        public void Should_return_0A0B_when_all_digit_and_position_wrong(string guess, string secret)
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(mock => mock.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //when
            string answer = game.Guess(guess);

            //then
            Assert.Equal("0A0B", answer);
        }

        [Theory]
        [InlineData("1 2 3 4", "1234")]
        [InlineData("5 6 7 8", "5678")]
        public void Should_return_4A0B_when_all_digit_and_position_correct(string guess, string secret)
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(mock => mock.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //when
            string answer = game.Guess(guess);

            //then
            Assert.Equal("4A0B", answer);
        }

        [Theory]
        [InlineData("4 3 1 2", "1234")]
        [InlineData("4 3 2 1", "1234")]
        [InlineData("5 2 4 1", "1425")]
        public void Should_return_0A4B_when_all_digit_correct_and_all_position_wrong(string guess, string secret)
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(mock => mock.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //when
            string answer = game.Guess(guess);

            //then
            Assert.Equal("0A4B", answer);
        }

        [Theory]
        [InlineData("1 2 3 4", "1423", "1A3B")]
        [InlineData("1 4 3 2", "1423", "2A2B")]
        [InlineData("2 4 1 3", "1423", "2A2B")]
        public void Should_return_result_when_all_digits_correct_but_some_positions_wrong(string guess, string secret,
            string bullcows)
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(mock => mock.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //when
            string answer = game.Guess(guess);

            //then
            Assert.Equal(bullcows, answer);
        }

        [Theory]
        [InlineData("2 1 5 6", "1234", "0A2B")]
        [InlineData("6 1 5 8", "1234", "0A1B")]
        [InlineData("3 1 2 6", "1234", "0A3B")]
        public void Should_return_result_when_some_digits_correct_and_all_positions_wrong(string guess, string secret,
            string bullcows)
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(mock => mock.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //when
            string answer = game.Guess(guess);

            //then
            Assert.Equal(bullcows, answer);
        }

        [Theory]
        [InlineData("1 5 7 8", "1234", "1A0B")]
        [InlineData("1 2 5 6", "1234", "2A0B")]
        [InlineData("1 2 5 3", "1234", "2A1B")]
        [InlineData("1 4 2 5", "1234", "1A2B")]
        public void Should_return_result_when_some_digits_correct_and_some_positions_correct(string guess, string secret,
            string bullcows)
        {
            //given
            var mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(mock => mock.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //when
            string answer = game.Guess(guess);

            //then
            Assert.Equal(bullcows, answer);
        }

        [Theory]
        [InlineData("1 2 3 4 5")]
        [InlineData("1 2 3")]
        public void Should_return_wrong_input_tip_when_number_of_digits_is_not_4(string guess)
        {
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);

            string answer = game.Guess(guess);

            Assert.Equal("Wrong Input, input again", answer);
        }

        [Theory]
        [InlineData("1 2 3 1")]
        [InlineData("1 1 1 1")]
        public void Should_return_wrong_input_tip_when_some_digits_are_same(string guess)
        {
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);

            string answer = game.Guess(guess);

            Assert.Equal("Wrong Input, input again", answer);
        }

        [Theory]
        [InlineData("1 2 23 4")]
        [InlineData("1 2 d 4")]
        [InlineData("d e t @")]
        [InlineData("dfdsf 1 2 3")]
        [InlineData("d ` $ @")]
        public void Should_return_wrong_input_tip_when_some_input_are_not_digit(string guess)
        {
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);

            string answer = game.Guess(guess);

            Assert.Equal("Wrong Input, input again", answer);
        }

        [Theory]
        [InlineData("12 3 4")]
        [InlineData("1234")]
        public void Should_return_wrong_input_tip_when_digits_not_separated_by_space(string guess)
        {
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);

            string answer = game.Guess(guess);

            Assert.Equal("Wrong Input, input again", answer);
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
