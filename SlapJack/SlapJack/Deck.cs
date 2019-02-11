using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapJack
{
    class Deck
    {
        private static readonly Random getrandom = new Random();

        public static Card[] cards = new Card[52];

        public Deck()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    string suit = "";
                    if (i == 0) { suit = "Clubs"; }
                    if (i == 1) { suit = "Diamonds"; }
                    if (i == 2) { suit = "Hearts"; }
                    if (i == 3) { suit = "Spades"; }
                    string face = "";
                    if (j == 0) { face = "2"; }
                    if (j == 1) { face = "3"; }
                    if (j == 2) { face = "4"; }
                    if (j == 3) { face = "5"; }
                    if (j == 4) { face = "6"; }
                    if (j == 5) { face = "7"; }
                    if (j == 6) { face = "8"; }
                    if (j == 7) { face = "9"; }
                    if (j == 8) { face = "10"; }
                    if (j == 9) { face = "Ace"; }
                    if (j == 10) { face = "Jack"; }
                    if (j == 11) { face = "Queen"; }
                    if (j == 12) { face = "King"; }
                    Card temp = new Card(suit, face);
                    cards[(i * 13) + j] = temp;
                }
            }
        }

        public void shuffle()
        {
            for (int i = cards.Length - 1; i > 0; --i)
            {
                int k = getrandom.Next(i + 1);
                Card temp = cards[i];
                cards[i] = cards[k];
                cards[k] = temp;
            }
        }

    }
}
