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
            //List<Card> CreateDeck()
        {
            //int index = 0;
            
            AddCardsForSuit(Card.Suits.Clubs);
            AddCardsForSuit(Card.Suits.Diamonds);
            AddCardsForSuit(Card.Suits.Hearts);
            AddCardsForSuit(Card.Suits.Spades);
          
         
        }

        public void PrintDeck()
        {
            // for (int i = 0; i < 52; i++)
            // { 
            //     Console.WriteLine($"{_cardList[i].Value} {_cardList[i].Suit}");
            // }
            //
            // return "hello";
            foreach (Card card in _cardList)
            {
                Console.WriteLine(card.Name);
            }
            
        }

        public int NumberOfCards()
        {
            return _cardList.Count;
        }

        private void AddCardsForSuit(Card.Suits suit)
        {
            for (int i = 1; i <= 10; i++)
            {
                
                _cardList.Add(new Card(i , suit));
            }
            _cardList.Add(new Card(10, suit));
            _cardList.Add(new Card(10, suit));
            _cardList.Add(new Card(10, suit));
            
        }
        
        
        
    }
    
    //Constructor that will create cards
    //add to CardList
    
}