using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_blackjack
{
    public abstract class Player
    {

        private readonly ICollection<Card> _hand = new List<Card>(); //playerhand property can be anything that 
        //conforms ot collection interface. And collection has to be collection of cards
        private readonly IDeck _deck;

        protected virtual int MaxPlayerHandValue { get; } 

        protected Player(IDeck deck) 
        {
            _deck = deck;
        }
        
        
        public void DrawCard()
        {
            var playerCard = _deck.DrawCard();
            _hand.Add(playerCard);
            
        }
        
        
        public int HandValue()
        {
            
            return _hand.Sum(card => card.Value);
        }
        


        protected void HitCard()
        {

            if (HandValue() < MaxPlayerHandValue)
            {
                DrawCard();
            }

        }

        public abstract void PlayTurn();

    }
}