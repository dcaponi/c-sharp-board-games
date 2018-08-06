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
        private string gameName;
        private int maxNumberOfPlayers;

        public Game( string gameName, int maxNumberOfPlayers )
        {
            this.gameName = gameName;
            this.maxNumberOfPlayers = maxNumberOfPlayers;
            userList = new Queue<User>();
            gameBoardFactory = new GameBoardFactory();
            gameOver = false;
            createUsers( this.maxNumberOfPlayers );
            createBoard( this.gameName );
            startGame();
        }

        protected void startGame()
        {
            while (!gameOver)
            {
                User currentUser = userList.Dequeue();
                facilitatePlayerGuessOnBoard(currentUser);
                userList.Enqueue(currentUser);
                if (gameOver)
                {
                    Console.WriteLine("Congratulations " + currentUser.name + " You Win!!!!");
                    Console.WriteLine("Play again? y/n");
                    string restart = Console.ReadLine().ToLower();
                    if (restart[0] == 'y')
                    {
                        createBoard( this.gameName );
                        gameOver = false;
                    }
                    if (restart[0] == 'n')
                    {
                        Console.WriteLine("Return to main menu? y/n");
                        string goToMenu = Console.ReadLine().ToLower();
                        if( goToMenu[0] == 'n' )
                        {
                            Environment.Exit(0);
                        }
                    }
                }
            }
        }

        protected abstract void facilitatePlayerGuessOnBoard( User user );

        protected abstract void createBoard( string gameName );

        protected void createUsers( int maxNumberOfPlayers )
        {
            Console.WriteLine("How Many Players ( Enter a number between 1 and " + maxNumberOfPlayers + " ):" );
            int users = 0;
            bool userCountValid = false;
            while (!userCountValid)
            {
                string usersInput = Console.ReadLine();
                userCountValid = Int32.TryParse(usersInput, out users) && users > 0 && users < 4;
                if (!userCountValid)
                {
                    Console.WriteLine("Enter a number");
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
