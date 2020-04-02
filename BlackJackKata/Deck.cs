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
            
            AddCardsForSuit(Suit.Clubs);
            AddCardsForSuit(Suit.Diamonds);
            AddCardsForSuit(Suit.Hearts);
            AddCardsForSuit(Suit.Spades);
            
           //AddCardsForSuitAndValue(Card.Values.Jack, Card.Suits.Clubs);
           
          
               
          
         
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

        // private void AddCardsForSuit(Card.Suits suit)
        // {
        //     for (int i = 1; i <= 10; i++)
        //     {
        //         
        //         _cardList.Add(new Card(i , suit));
        //     }
        //     _cardList.Add(new Card(10, suit)); //jack
        //     _cardList.Add(new Card(10, suit)); //queen
        //     _cardList.Add(new Card(10, suit)); //king
        //     
        // }

        private void AddCardsForSuit(Suit suit)
        {
            
           //  string[] valueNames = Enum.GetNames(typeof(Card.Values));
           //  Card.Values [] values = (Card.Values[])Enum.GetValues(typeof(Card.Values));
           //
            // for (int i = 0; i <= 10; i++)
            // {
            //     _cardList.Add(new Card(Enum.GetValues(typeof(Suit))));
            // }

            foreach (CardFace cardFace in Enum.GetValues(typeof(CardFace)))
            {
                _cardList.Add(new Card(cardFace, suit));
            }
           
           // _cardList.Add(new Card(Card.Values.Jack, suit));
           // _cardList.Add(new Card(Card.Values.Queen, suit));
           // _cardList.Add(new Card(Card.Values.King, suit));
           
           // foreach (var value in Enum.GetNames(typeof(Card.Values)))
           // foreach (var suit in Enum.GetNames(typeof(Card.Suits)))
           //
           // {
           //     _cardList.Add(new Card(value, suit));
           //    // AddCardsForSuitAndValue(value, suit);
           // }
           //
           
           
           
            
        }

       
        
    }
    
    //Constructor that will create cards
    //add to CardList
    
}