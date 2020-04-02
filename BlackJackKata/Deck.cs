using System;
using System.Collections.Generic;

namespace blackjack
{
    public class Deck
    {
        public readonly List<Card> _cardList = new List<Card>();


        public Deck()
        {
            CreateDeck();
        }

        public void CreateDeck()

        {
            AddCardsForSuit(Suit.Clubs);
            AddCardsForSuit(Suit.Diamonds);
            AddCardsForSuit(Suit.Hearts);
            AddCardsForSuit(Suit.Spades);
        }

        public void PrintDeck()
        {
            // for (int i = 0; i < 52; i++)
            // { 
            //     Console.WriteLine($"{_cardList[i].Value} {_cardList[i].Suit}");
            // }
            //
            // return "hello";


            // foreach (var suit in Enum.GetNames(typeof(Card.Suits)))
            // foreach (Card card in _cardList)
            // {
            //    
            //     Console.WriteLine($"{card.Value} of {suit}");
            // }


            //This prints out all cards based on enums not cardlist

            // foreach (var suit in Enum.GetNames(typeof(Card.Suits)))
            //     foreach (var value in Enum.GetNames(typeof(Card.Values)))
            //
            // {
            //    
            //  
            //     Console.WriteLine($"{value} of {suit}");
            // }
        }

        public int NumberOfCards()
        {
            return _cardList.Count;
        }
        
        private void AddCardsForSuit(Suit suit)
        {
            foreach (CardFace cardFace in Enum.GetValues(typeof(CardFace))) _cardList.Add(new Card(cardFace, suit));
        }
    }
}