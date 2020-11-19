using System;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private readonly string secret;
        private int leftChance = 6;
        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            this.secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue => leftChance > 0 ? true : false;

        public string Guess(string guess)
        {
            string guessWithoutSpace;

            return TryParseGuess(guess, out guessWithoutSpace)
                ? this.Compare(this.secret, guessWithoutSpace)
                : "Wrong Input, input again";
        }

        private string Compare(string secret, string guess)
        {
            var bulls = secret.Zip(guess, (secretChar, guessChar) => secretChar == guessChar)
                .Where(match => match == true)
                .Count();
            var cows = secret.Where(secretChar => guess.Contains(secretChar)).Count() - bulls;

            CountLeftChance(bulls);

            return $"{bulls}A{cows}B";
        }

        private void CountLeftChance(int bulls)
        {
            this.leftChance =
                bulls == 4
                ? 0
                : this.leftChance - 1;
        }

        private bool TryParseGuess(string guess, out string guessWithoutSpace)
        {
            var pattern = @"^\s*(\d\s){3}\d\s*$";
            Match m = Regex.Match(guess, pattern);

            guessWithoutSpace = guess.Replace(" ", string.Empty);
            var distinct = guessWithoutSpace.Distinct().Count() == 4;

            return distinct && m.Success;
        }
    }
}