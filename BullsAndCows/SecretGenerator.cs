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
            var len = 4;
            return Enumerable.Range(0, 10)
                             .OrderBy(num => random.Next())
                             .Select(num => $"{num}")
                             .Take(len)
                             .Aggregate((pre, current) => pre + current);
        }
    }
}