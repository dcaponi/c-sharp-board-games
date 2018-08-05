using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGameSuite
{
    abstract class User
    {
        protected IPlayable playStrategy;
        public string name { get; }
        protected User( string name )
        {
            this.name = name;
        }
        public Move Play()
        {
           return playStrategy.Play(this);
        }
    }
}
