using kata_blackjack;
using NUnit.Framework;

namespace blackjackTests
{
    public class DealerTests
    {

        [Test]
        public void StaysOn17()
        {
            var testDeck = new TestDeck(new[]
            {
                new Card(CardFace.Ten, Suit.Hearts),
                new Card(CardFace.Seven, Suit.Spades),
                new Card(CardFace.Jack, Suit.Diamonds),
            });
            var dealer = new Dealer(testDeck);
        
            dealer.PlayTurn();
            
            Assert.AreEqual(17, dealer.HandValue());
        }
        
        [Test]
        public void HitsUnder17()
        {
            var testDeck = new TestDeck(new[]
            {
                new Card(CardFace.Ten, Suit.Hearts),
                new Card(CardFace.Six, Suit.Spades),
                new Card(CardFace.Ten, Suit.Diamonds),
            });
            var dealer = new Dealer(testDeck);
            
            dealer.PlayTurn();
            
            Assert.AreEqual(26, dealer.HandValue());
        }
        
        [Test]
        public void StaysOn20()
        {
            var testDeck = new TestDeck(new[]
            {
                new Card(CardFace.Ten, Suit.Hearts),
                new Card(CardFace.Jack, Suit.Spades),
                new Card(CardFace.Ace, Suit.Diamonds),
                new Card(CardFace.Five, Suit.Diamonds),
            });
            var dealer = new Dealer(testDeck);
      
            dealer.PlayTurn();

            Assert.AreEqual(20, dealer.HandValue());

        }

        [Test]
        public void StartsWithTwoCards()
        {
            var testDeck = new TestDeck(new[]
            {
                new Card(CardFace.Five, Suit.Hearts),
                new Card(CardFace.Five, Suit.Spades),
            });
            var dealer = new Dealer(testDeck);

            Assert.AreEqual(10, dealer.HandValue());
        }
        
       
    }
}