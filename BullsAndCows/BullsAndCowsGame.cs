﻿using System;
using System.Linq;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private readonly string secret;
        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            this.secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
            var guessWithoutSpace = guess.Replace(" ", string.Empty);
            return this.Compare(this.secret, guessWithoutSpace);
        }

        private string Compare(string secret, string guess)
        {
            var bulls = secret.Zip(guess, (secretChar, guessChar) => secretChar == guessChar)
                .Where(match => match == true)
                .Count();
            int cows;

            if (secret.Where(secretChar => guess.Contains(secretChar)).Count() == 4)
            {
                cows = 4 - bulls;
                return $"{bulls}A{cows}B";
            }

            cows = secret.Where(secretChar => guess.Contains(secretChar)).Count();
            if (cows < 4 && cows > 0)
            {
                return $"{bulls}A{cows}B";
            }

            return $"{bulls}A0B";
        }
    }
}