using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BullsAndCows;
using Xunit;

namespace BullsAndCowsTest
{
    public class SecretGenetorTest
    {
        [Fact]
        public void Should_return_non_repeatable_secret_numbers()
        {
            var secretGenerator = new SecretGenerator();
            var secret = secretGenerator.GenerateSecret();

            var secretChars = secret.ToCharArray();
            var len = 4;
            var actual = secretChars.Length == len && secretChars.Distinct().Count() == len;
            Assert.Equal(true, actual);
        }
    }
}
