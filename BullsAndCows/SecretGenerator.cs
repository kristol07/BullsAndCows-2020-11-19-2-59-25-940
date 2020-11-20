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
            return Enumerable.Range(0, 10)
                             .OrderBy(num => random.Next())
                             .Select(num => $"{num}")
                             .Take(4)
                             .Aggregate((pre, current) => pre + current);
        }
    }
}