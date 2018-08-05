using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameSuite
{
    class GameFactory
    {
        public GameFactory() { }
        public Game CreateGame( int option )
        {
            if( option == 1)
            {
                return new WoFGame();
            }
            if (option == 2)
            {
                return new ConnectFourGame();
            }
            return null;
        }
    }
}
