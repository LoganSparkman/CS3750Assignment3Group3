using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapJack
{
    class Player
    {
        /// <summary>
        /// cards player has
        /// </summary>
        Hand hand;

        /// <summary>
        /// Did the player slap first?
        /// </summary>
        private bool slapped = false;

        public bool slappedFirst
        {
            get { return slapped; }
            set { slapped = value; }
        }

        public Player()
        {
            hand = new Hand();
        }

    }
}
