using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapJack
{
    class Board
    {
        public Card[] middlePile = new Card[52];
        int totalCards = 0;
        static bool isAJack;

        public Board()
        {

        }

        public void addCard(Card card, Hand hand)
        {
            middlePile[totalCards] = card;
            totalCards++;
        }

        public void isJack(Card card)
        {
            if (card.getface() == "Jack")
            {
                isAJack = true;
            }
            else
            {
                isAJack = false;
            }
            Slap(isAJack);
        }

        public void Slap(bool isAJack)
        {
            if(true)
            {

            }
        }

    }
}

/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapJack
{
  class Board
  {
      public Player[] player;
      public Hand[] hand;
      public Deck[] deck;
      public Card[] cards = new Card[26];

      int totalCards = 0;

      public void addCard(Card card)
      {
          cards[totalCards] = card;
          totalCards++;
      }

      public Board()
      {
          player = new Player[2];
          hand = new Hand[1];
          deck = new Deck[1];

      }
      public void addToPile(int newHand, Card newCard)
      {

          player[newHand].addCard(newCard);
      }

      public void clearHand()
      {
          player = new Player[2];
          hand = new Hand[1];
          deck = new Deck[1];
          player one = new Player();
          player two = new Player();
          hand = new Hand();
          deck = new Deck();
          player[0] = one;
          player[1] = two;
          
      }
  }
}
*/
