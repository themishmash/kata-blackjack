using System.Linq;
using blackjack;
using NUnit.Framework;

namespace blackjackTests
{
    public class Tests
    {  
      
        
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Deck_StartsWith52Cards()
        {
            Deck deck = new Deck();
            Assert.AreEqual(52, deck.NumberOfCards());
        }

        [Test]
         public void Deck_deckContainsSpecificCards()
         {
             Deck deck = new Deck();
            
             
             Assert.AreEqual(1,deck._cardList.Count(c=>c.Value == 1 && c.Suit == Card.Suits.Clubs));
         }
        
        
        
        
        
        
        
        
    }
}