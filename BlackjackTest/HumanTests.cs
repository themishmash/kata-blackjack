using kata_blackjack;
using NUnit.Framework;

namespace blackjackTests
{
    public class HumanTests
    {
        [Test]
        public void ValueOfCards() 
        {
            //Given
            var testDeck = new TestDeck((new []
            {
                new Card(CardFace.Eight, Suit.Clubs), 
                new Card(CardFace.Eight, Suit.Diamonds)
                
            }));
            var human = new Human(testDeck);
            
            //When
            human.DrawCard();
            human.DrawCard();

            //Then
            Assert.AreEqual(16, human.HandValue());
        }
    }
}