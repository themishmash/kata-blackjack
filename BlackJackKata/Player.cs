using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_blackjack
{
    public abstract class Player
    {
        private readonly ICollection<Card> Hand = new List<Card>(); //playerhand property can be anything that 
        //conforms to collection interface. And collection has to be collection of cards
        private readonly IDeck _deck;

        private int _value;
        // private int _hardValue;
        
        

        protected virtual int MaxPlayerHandValue { get; } 

        protected Player(IDeck deck) 
        {
            _deck = deck;
            DrawCard();
            DrawCard();
        }


        protected void DrawCard()
        {
            var playerCard = _deck.DrawCard();
            Hand.Add(playerCard);
            
        }
        
        
        // public int HandValue()
        // {
        //     return Hand.Sum(card => card.ValueOfCardFace);
        // }
        
        public int HandValue()
        {
            _value = Hand.Sum(card => card.ValueOfCardFace);
            if (Hand.Any(card => card.CardFace == CardFace.Ace) && _value <= 11) 
            {
                return _value + 10;
            }
            // _hardValue = _softValue + 10;
            // foreach (Card card in Hand)
            // {
            //     if (card.CardFace == CardFace.Ace && _hardValue <= 21)
            //         return _hardValue;
            // }
            return _value;
        }
        
        


        public string PrintPlayerHand()
        {
            var returnString = string.Empty;
            foreach (var card in Hand)
            {
                returnString += card.CardFace + " " + card.Suit + " ";
            }
            
            return returnString;
        }
        

        public abstract void PlayTurn();

    }
}