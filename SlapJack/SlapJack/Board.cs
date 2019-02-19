using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SlapJack
{
    class Board
    {
        public Card[] middlePile;
        public int totalCards = 0;

        public Board()
        {
            middlePile = new Card[52];
        }

        public void addCard(Card card)
        {
            middlePile[totalCards] = card;
            totalCards++;
        }

        public void clear()
        {
            middlePile = new Card[52];
            totalCards = 0;
        }

        public void wait(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(2000);
        }


    }
}