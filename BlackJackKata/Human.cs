using System;
using System.Collections.Generic;

namespace blackjack
{
    public class Human
    
    {
        public readonly List<Card> HumanList = new List<Card>();

        public Human()
        {
            
        }
        
        public void AddOneCardToHumanHand(Deck deck)
        {
            var humanCard = deck.DrawOneCardFromDeck();
            HumanList.Add(humanCard);
            
        }

        public int NumberOfHumanCards()
        {
            return HumanList.Count;
        }
        
        public void PrintHumanHand()
        {
            foreach (Card card in HumanList)
            {
                Console.WriteLine($"{card.CardFace} of {card.Suit}");
            }
        }

    }
}