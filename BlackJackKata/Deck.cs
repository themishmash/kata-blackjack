using System;
using System.Collections.Generic;

namespace blackjack
{
    public class Deck
    {
        private static readonly Random rng = new Random(); //This is to do with shuffle cards
        public readonly List<Card> CardList = new List<Card>();


        public Deck()
        {
            CreateDeck();
            ShuffleCards();
        }

        public void CreateDeck()

        {
            AddCardsForSuit();
            // AddCardsForSuit(Suit.Diamonds);
            // AddCardsForSuit(Suit.Hearts);
            // AddCardsForSuit(Suit.Spades);
        }

        public void ShuffleCards()
        {
            var n = CardList.Count;
            while (n > 1)
            {
                n--;
                var k = rng.Next(n + 1);
                var value = CardList[k];
                CardList[k] = CardList[n];
                CardList[n] = value;
            }
        }

        public void PrintDeck()
        {
            foreach (var card in CardList) Console.WriteLine($"{card.CardFace} of {card.Suit}");
        }

        public int NumberOfCards()
        {
            return CardList.Count;
        }

        public Card DrawOneCardFromDeck()
        {
            if (CardList.Count > 0)
            {
                var card = CardList[0];
                CardList.Remove(card);
                //Console.WriteLine($"{card.CardFace} of {card.Suit}");
                return card;
            }

            return null;
            //foreach (var card in _cardList) Console.WriteLine($"{card.CardFace} of {card.Suit}");
        }

        private void AddCardsForSuit()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            foreach (CardFace cardFace in Enum.GetValues(typeof(CardFace)))
                CardList.Add(new Card(cardFace, suit));
        }
    }
}