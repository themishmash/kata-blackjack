using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_blackjack
{
    public class Player
    {

        public readonly ICollection<Card> PlayerHand = new List<Card>(); 
        private readonly IDeck _deck;

        public Player(IDeck deck) 
        {
            _deck = deck;
        }
        
        public void AddOneCardToHand()
        {
            var playerCard = _deck.DrawOneCardFromDeck();
            PlayerHand.Add(playerCard);
            
        }
        
        public int NumberOfPlayerCards()
        {
            return PlayerHand.Count;
        }
        
        public int CardTotalValue()
        {
            return PlayerHand.Sum(card => card.Value);
        }
        
        public void PrintPlayerHand()
        {
            foreach (Card card in PlayerHand)
            {
                Console.WriteLine($"{card.CardFace} of {card.Suit}");
            }
        }
    }
}