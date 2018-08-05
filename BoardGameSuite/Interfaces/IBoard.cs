using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameSuite
{
    interface IBoard
    {
        void acceptMove(Move move);
        bool isSolved();
    }
}
