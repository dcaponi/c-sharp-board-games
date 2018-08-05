using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace BoardGameSuite
{
    class GuessText : IPlayable
    {
        public Move Play(User currentUser)
        {
            bool valid = false;
            string guess;
            Console.Write("\n" + currentUser.name + " enter your guess or type exit to quit: ");
            do
            {
                guess = Console.ReadLine().Trim().ToUpper();

                if (guess == "EXIT")
                {
                    Environment.Exit(0);
                }
                else if (Regex.IsMatch(guess, @"^[a-zA-Z]+$") && guess.Length > 0)
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Type in a valid guess.");
                }
            } while (!valid);

            return new WoFMove( guess );
        }
    }
}
