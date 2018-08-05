using System;

namespace BoardGameSuite
{
    class Program
    {
        static void Main(string[] args)
        {
            GameFactory gameFactory = new GameFactory();
            Console.WriteLine("Which game would you like to play? ");
            Console.WriteLine("Wheel of Fortune (1)");
            bool validOption = false;
            int option = -1;
            while (!validOption)
            {
                string optionInput = Console.ReadLine();
                validOption = Int32.TryParse(optionInput, out option) && option > 0 && option < 2;
                if (!validOption)
                {
                    Console.WriteLine("Enter a number ( 1 )");
                }
            }
            Game game = gameFactory.CreateGame(option);
        }
    }
}
