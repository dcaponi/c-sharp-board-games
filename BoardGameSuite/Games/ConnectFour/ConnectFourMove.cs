using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameSuite
{
    class ConnectFourMove : Move
    {
        private string color;
        private int column;

        private int neighborsRight;

        private int neighborsBottomRight;
        private int neighborsBottom;
        private int neighborsBottomLeft;

        private int neighborsLeft;

        private int neighborsTopLeft;
        private int neighborsTop;
        private int neighborsTopRight;
        public ConnectFourMove( string color, int column )
        {
            this.color = color;
            this.column = column;
        }
    }
}
