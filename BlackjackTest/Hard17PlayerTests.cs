using kata_blackjack;
using NUnit.Framework;

namespace blackjackTests
{
    public class Hard17PlayerTests
    {

        [Test]
        public void HitsOn17()
        {
            var testDeck = new DeckMock(new[]
            {
                new Card(CardFace.Ten, Suit.Hearts),
                new Card(CardFace.Seven, Suit.Spades),
                new Card(CardFace.Jack, Suit.Diamonds),
            });
            var hard17Player = new Hard17Player(testDeck);
        
            hard17Player.PlayTurn();
            
            Assert.AreEqual(27, hard17Player.HandValue());
        }
        
        [Test]
        public void HitsUnder17()
        {
            var testDeck = new DeckMock(new[]
            {
                new Card(CardFace.Ten, Suit.Hearts),
                new Card(CardFace.Six, Suit.Spades),
                new Card(CardFace.Ten, Suit.Diamonds),
            });
            var hard17Player = new Hard17Player(testDeck);
            
            hard17Player.PlayTurn();
            
            Assert.AreEqual(26, hard17Player.HandValue());
        }
        
        [Test]
        public void StaysOn20()
        {
            var testDeck = new DeckMock(new[]
            {
                new Card(CardFace.Ten, Suit.Hearts),
                new Card(CardFace.Jack, Suit.Spades),
                new Card(CardFace.Ace, Suit.Diamonds),
                new Card(CardFace.Five, Suit.Diamonds),
            });
            var hard17Player = new Hard17Player(testDeck);
      
            hard17Player.PlayTurn();

            Assert.AreEqual(20, hard17Player.HandValue());

        }

        [Test]
        public void StartsWithTwoCards()
        {
            var testDeck = new DeckMock(new[]
            {
                new Card(CardFace.Five, Suit.Hearts),
                new Card(CardFace.Five, Suit.Spades),
            });
            var hard17Player = new Hard17Player(testDeck);

            Assert.AreEqual(10, hard17Player.HandValue());
        }
        
    }
}