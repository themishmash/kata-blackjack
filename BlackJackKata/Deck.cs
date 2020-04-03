using System;
using System.Collections.Generic;
using System.Linq;

namespace blackjack
{
    public class Deck
    {
        public readonly List<Card> _cardList = new List<Card>();

        private static Random rng = new Random();  

        
        public Deck()
        {
            CreateDeck();
            ShuffleCards();
        }

        public void CreateDeck()

        {
            AddCardsForSuit(Suit.Clubs);
            AddCardsForSuit(Suit.Diamonds);
            AddCardsForSuit(Suit.Hearts);
            AddCardsForSuit(Suit.Spades);
            
            
            
        }
        
        public void ShuffleCards()
        {  
            int n = _cardList.Count;  
            while (n > 1) {  
                n--;  
                int k = rng.Next(n + 1);  
                Card value = _cardList[k];  
                _cardList[k] = _cardList[n];  
                _cardList[n] = value;  
            }  
        }

        public void PrintDeck()
        {
            foreach (var card in _cardList) Console.WriteLine($"{card.CardFace} of {card.Suit}");
        }

        public int NumberOfCards()
        {
            return _cardList.Count;
        }
        
        public void DrawOneCardFromDeck()
        {
            if (_cardList.Count > 0)
            {
                Card card = _cardList[0];
               _cardList.Remove(card);
                //Console.WriteLine($"{card.CardFace} of {card.Suit}");
            }

            //foreach (var card in _cardList) Console.WriteLine($"{card.CardFace} of {card.Suit}");
            
        }

        private void AddCardsForSuit(Suit suit)
        {
            foreach (CardFace cardFace in Enum.GetValues(typeof(CardFace)))
            {
                _cardList.Add(new Card(cardFace, suit));
                
            }
            //shuffle cardlist here? or at create deck?
        }

        
    }
}