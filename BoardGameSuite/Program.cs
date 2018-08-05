using System;

namespace BoardGameSuite
{
    class Program
    {
        static void Main(string[] args)
        {
            GameFactory gameFactory = new GameFactory();
            Console.WriteLine("Which game would you like to play? ");
            Console.WriteLine("1 ) Wheel of Fortune");
            Console.WriteLine("2 ) Connect Four");
            bool validOption = false;
            int option = -1;
            while (!validOption)
            {
                string optionInput = Console.ReadLine();
                validOption = Int32.TryParse(optionInput, out option) && option > 0 && option < 3;
                if (!validOption)
                {
                    Console.WriteLine("Enter a number on the list");
                }
            }
            Game game = gameFactory.CreateGame(option);
        }
    }
}
