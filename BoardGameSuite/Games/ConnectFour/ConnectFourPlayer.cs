using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameSuite
{
    class ConnectFourPlayer : User
    {
        ConnectFourPlayer( String name ) : base( name )
        {
            playStrategy = new DropChip();
        }
    }
}
