using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameSuite
{
    class WoFGame : Game
    {
        private WoFBoard board;
        public WoFGame() : base( "wof", 3 )
        {
            Console.WriteLine("Wheel... Of... FORTUNE!!!");
        }

        protected override void createBoard( string gameName )
        {
            board = (WoFBoard)gameBoardFactory.CreateGameBoard(gameName);
        }

        protected override void facilitatePlayerGuessOnBoard( User currentUser )
        {
            do {
                Move currentPlay = currentUser.Play();
                board.acceptMove(currentPlay);
            } while (board.goAgain());

            gameOver = board.isSolved();
        }
    }
}
