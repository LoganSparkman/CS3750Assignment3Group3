using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapJack
{
    class Board
    {
        public Card[] middlePile = new Card[52];
        public int totalCards = 0;

        public Board()
        {
            Player player1 = new Player();
            Player player2 = new Player();
            Deck deck = new Deck();
            deck.shuffle();
            Deck.cards[0].getSuit();
            Deck.cards[0].getface();
            Hand hand1 = new Hand();

            Card newcard = new Card(Deck.cards[0].getSuit(), Deck.cards[0].getface());

            hand1.addCard(newcard);
            Hand hand2 = new Hand();
        }

        public void addCard(Card card, Hand hand)
        {
            middlePile[totalCards] = card;
            totalCards++;
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
