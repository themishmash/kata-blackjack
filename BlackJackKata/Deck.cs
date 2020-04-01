using System;
using System.Collections.Generic;

namespace blackjack
{
    public class Deck
    {
        
        //this should be listdfdf
        private List<Card> _cardList = new List<Card>();
        

        public Deck()
        {
            
        }

        public List<Card> CreateDeck()
        {
            for (int i = 0; i < 52; i++)
            {

                int value = i;
                _cardList.Add(new Card(value));
            }

            return _cardList;
        }
     
    }
    
    //Constructor that will create cards
    //add to CardList
    
}