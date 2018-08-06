using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameSuite
{
    class ConnectFourBoard : IBoard
    {
        public int rows { get; set; }
        public int columns { get; set; }
        private int movesMade;
        private List< Stack<ConnectFourMove> > board;

        public ConnectFourBoard()
        {
            board = new List<Stack<ConnectFourMove>>();
            movesMade = 0;
            initializeBoard();
        }
        private void initializeBoard()
        {
            for( int i = 0; i < columns; i++)
            {
                board.Add(new Stack<ConnectFourMove>());
            }
        }

        public bool isFull()
        {
            return movesMade == rows * columns;
        }
        public bool isSolved()
        {
            return false;
        }

        public void acceptMove( Move move )
        {

            movesMade++;
        }
    }
}
