using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameSuite
{
    interface IPlayable
    {
        Move Play(User user);
    }
}
