using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameSuite
{
    class WoFGame : Game
    {
        private WoFBoard board;

        public WoFGame()
        {
            Console.WriteLine("Wheel... Of... FORTUNE!!!");
            gameName = "wof";
            maxPlayers = 3;
            createUsers(maxPlayers);
            startGame();
        }

        protected override void startGame()
        {
            board = (WoFBoard) gameBoardFactory.CreateGameBoard(gameName);
            while ( !gameOver )
            {
                User currentUser = userList.Dequeue();
                facilitatePlayerGuessOnBoard( currentUser );
                userList.Enqueue( currentUser );
                if( gameOver )
                {
                    Console.WriteLine("Congratulations " + currentUser.name + " You Win!!!!");
                    Console.WriteLine("Play again? y/n");
                    string restart = Console.ReadLine().ToLower();
                    if( restart[0] == 'y' )
                    {
                        board = (WoFBoard) gameBoardFactory.CreateGameBoard(gameName);
                        gameOver = false;
                    }
                }
            }
            
        }

        private void facilitatePlayerGuessOnBoard( User currentUser )
        {
            do {
                Move currentPlay = currentUser.Play();
                board.acceptMove(currentPlay);
            } while (board.goAgain());

            gameOver = board.isSolved();
        }
    }
}
