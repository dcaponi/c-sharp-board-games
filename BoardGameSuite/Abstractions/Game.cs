using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameSuite
{
    abstract class Game
    {
        protected Queue<User> userList;
        protected GameBoardFactory gameBoardFactory;
        protected bool gameOver;
        protected string gameName;
        protected int maxPlayers;

        public Game()
        {
            userList = new Queue<User>();
            gameBoardFactory = new GameBoardFactory();
            gameOver = false;
        }

        protected abstract void startGame();

        protected void createUsers( int maxNumberOfPlayers )
        {
            Console.WriteLine("How Many Users ( Enter 1, 2, or 3 ): ");
            int users = 0;
            bool userCountValid = false;
            while (!userCountValid)
            {
                string usersInput = Console.ReadLine();
                userCountValid = Int32.TryParse(usersInput, out users) && users > 0 && users < 4;
                if (!userCountValid)
                {
                    Console.WriteLine("Enter a number ( 1, 2, or 3 )");
                }
            }
            for (int i = 0; i < users; i++)
            {
                Console.WriteLine("Enter name for player " + (i + 1));
                string name = Console.ReadLine();
                User user = new WoFPlayer(name);
                userList.Enqueue(user);
            }
        }
    }
}
