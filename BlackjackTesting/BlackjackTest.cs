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
        public void NumberOfCardsInDeckTest()
        {
            Deck deck = new Deck();
            var cardList = deck.CreateDeck();
          
            Assert.AreEqual(52, cardList.Count);
            
        }
        
        
        
        
        
        
    }
}