﻿using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

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
            string guessWithoutSpace;
            if (TryParseGuess(guess, out guessWithoutSpace))
            {
                return this.Compare(this.secret, guessWithoutSpace);
            }
            else
            {
                return "Wrong Input, input again";
            }
        }

        private string Compare(string secret, string guess)
        {
            var bulls = secret.Zip(guess, (secretChar, guessChar) => secretChar == guessChar)
                .Where(match => match == true)
                .Count();
            var cows = secret.Where(secretChar => guess.Contains(secretChar)).Count() - bulls;

            return $"{bulls}A{cows}B";
        }

        private bool TryParseGuess(string guess, out string guessWithoutSpace)
        {
            var guessChars = guess.Trim().Split(' ');
            int num;
            if (guessChars.Length != 4 ||
                guessChars.Distinct().Count() != 4 ||
                guessChars.Where(guessChar => int.TryParse(guessChar, out num)).Count() != 4)
            {
                guessWithoutSpace = string.Empty;
                return false;
            }

            guessWithoutSpace = string.Join(string.Empty, guessChars);
            return true;
        }
    }
}