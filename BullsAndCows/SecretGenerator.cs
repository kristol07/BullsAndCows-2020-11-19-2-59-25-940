using System;
using System.Collections.Generic;
using System.Linq;

namespace BullsAndCows
{
    public class SecretGenerator
    {
        public virtual string GenerateSecret()
        {
            var random = new Random();
            var secretNumbers = Enumerable.Range(0, 10)
                .OrderBy(num => random.Next())
                .Select(num => $"{num}")
                .Take(4);
            return string.Join(string.Empty, secretNumbers);
        }
    }
}