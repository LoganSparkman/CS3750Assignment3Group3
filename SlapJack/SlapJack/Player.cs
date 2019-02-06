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
        /// number of cards player has
        /// </summary>
        int numCards;

        public Player()
        {
            hand = new Hand();
        }

        /// <summary>
        /// calculates the number of cards player has
        /// </summary>
        /*
        public void GetNumCards()
        {
            numCards = 0;

            foreach(Card card in hand)
            {
                if (card != null)
                    numCards++;
            }
        }
        */



    }
}
