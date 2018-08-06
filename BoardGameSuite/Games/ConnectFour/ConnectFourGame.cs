using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameSuite
{
    class ConnectFourGame : Game
    {
        private ConnectFourBoard board;

        public ConnectFourGame() : base("connectfour", 2)
        {
            Console.WriteLine("Let's Play Connect Four!!!");
            //Todo ask user how many rows/columns
        }

        protected override void facilitatePlayerGuessOnBoard(User currentUser)
        {
            Move currentPlay = currentUser.Play();
            board.acceptMove(currentPlay);
            gameOver = board.isSolved() || board.isFull();
        }

        protected override void createBoard( string gameName )
        {
            board = (ConnectFourBoard)gameBoardFactory.CreateGameBoard(gameName);
            board.rows = 6;
            board.columns = 7;
        }
    }
}
