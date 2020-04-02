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
            foreach (var card in _cardList) Console.WriteLine($"{card.CardFace} of {card.Suit}");
        }

        public int NumberOfCards()
        {
            return _cardList.Count;
        }

        private void AddCardsForSuit(Suit suit)
        {
            foreach (CardFace cardFace in Enum.GetValues(typeof(CardFace)))
            {
                _cardList.Add(new Card(cardFace, suit));
            }
        }
    }
}