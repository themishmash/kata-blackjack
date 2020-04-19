using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_blackjack
{
    public abstract class Player
    {

        public readonly ICollection<Card> Hand = new List<Card>(); //playerhand property can be anything that 
        //conforms ot collection interface. And collection has to be collection of cards
        private readonly IDeck _deck;

        public string HitCardInput;

        protected virtual int MaxPlayerHandValue { get; } 

        protected Player(IDeck deck) 
        {
            _deck = deck;
        }
        
        
        public void DrawCard()
        {
            var playerCard = _deck.DrawCard();
            Hand.Add(playerCard);
            
        }
        
        
        public int HandValue()
        {
            
            return Hand.Sum(card => card.Value);
        }
        


        // protected void HitCard()
        // {
        //
        //     if (HandValue() < MaxPlayerHandValue)
        //     {
        //         DrawCard();
        //     }
        //
        // }

        public abstract void PlayTurn();

    }
}