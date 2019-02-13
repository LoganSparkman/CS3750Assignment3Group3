﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapJack
{
    class Hand
    {
        public Card[] cards = new Card[52];
        public int totalCards = 0;
        public void addCard(Card newCard)
        {
            cards[totalCards] = newCard;
            totalCards++;
        }
        public Card dealCard()
        {
            Card returnCard = cards[0];
            for (int i = 0; i < totalCards - 1; i++)
            {
                cards[i] = cards[i + 1];
            }
            totalCards--;
            return returnCard;
        }
        public void addHand(Hand newhand)
        {
            for (int i = 0; i < newhand.totalCards; i++)
            {
                this.addCard(newhand.dealCard());
            }
        }
        public void clear()
        {
            cards = new Card[52];
            totalCards = 0;
        }
    }
}
