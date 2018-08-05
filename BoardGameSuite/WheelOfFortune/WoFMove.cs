using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameSuite
{
    class WoFMove : Move
    {
        public string guess { get; }
        public WoFMove( string guess )
        {
            this.guess = guess;
        }
    }
}
