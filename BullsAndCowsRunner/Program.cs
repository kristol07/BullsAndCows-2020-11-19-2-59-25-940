using System;
using BullsAndCows;

namespace BullsAndCowsRunner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SecretGenerator secretGenerator = new SecretGenerator();
            BullsAndCowsGame game = new BullsAndCowsGame(secretGenerator);
            while (game.CanContinue)
            {
                var input = Console.ReadLine();
                var output = game.Judge(input);
                Console.WriteLine(output);
            }

            Console.WriteLine("Game Over");
        }
    }
}