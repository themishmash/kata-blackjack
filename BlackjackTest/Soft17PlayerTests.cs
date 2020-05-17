using kata_blackjack;
using NUnit.Framework;

namespace blackjackTests
{
    public class Soft17PlayerTests
    {

        [Test]
        public void StaysOn17()
        {
            var testDeck = new DeckMock(new[]
            {
                new Card(CardFace.Ten, Suit.Hearts),
                new Card(CardFace.Seven, Suit.Spades),
                new Card(CardFace.Jack, Suit.Diamonds),
            });
            var soft17Player = new Soft17Player(testDeck);
        
            soft17Player.PlayTurn();
            
            Assert.AreEqual(17, soft17Player.HandValue());
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
            var soft17Player = new Soft17Player(testDeck);
            
            soft17Player.PlayTurn();
            
            Assert.AreEqual(26, soft17Player.HandValue());
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
            var soft17Player = new Soft17Player(testDeck);
      
            soft17Player.PlayTurn();

            Assert.AreEqual(20, soft17Player.HandValue());

        }

        [Test]
        public void StartsWithTwoCards()
        {
            var testDeck = new DeckMock(new[]
            {
                new Card(CardFace.Five, Suit.Hearts),
                new Card(CardFace.Five, Suit.Spades),
            });
            var soft17Player = new Soft17Player(testDeck);

            Assert.AreEqual(10, soft17Player.HandValue());
        }
        
    }
}