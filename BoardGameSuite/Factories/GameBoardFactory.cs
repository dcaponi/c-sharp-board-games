using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameSuite
{
    class GameBoardFactory
    {
        public GameBoardFactory() { }
        public IBoard CreateGameBoard( string boardOption )
        {
            if( boardOption == "wof" )
            {
                return new WoFBoard();
            }
            if (boardOption == "connectfour")
            {
                return new ConnectFourBoard();
            }
            return null;
        }
    }
}
