using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameSuite
{
    class WoFPlayer : User
    {
        public WoFPlayer( string name ) : base( name )
        {
            playStrategy = new GuessText();
        }
    }
}
