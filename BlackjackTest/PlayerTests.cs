using kata_blackjack;
using NUnit.Framework;

namespace blackjackTests
{
    public class PlayerTests
    {
        
        [Test]
        public void AceCanBeEleven()
        {
            var testDeck = new TestDeck(new[]
            {
                new Card(CardFace.Jack, Suit.Clubs), 
                new Card(CardFace.Ace, Suit.Diamonds),

            });

            var player = new PlayerImplementation(testDeck);

            Assert.AreEqual(21, player.HandValue());
        }
        
        [Test]
        public void AddThreeAces()
        {
            var testDeck = new TestDeck(new[]
            {
                new Card(CardFace.Ace, Suit.Clubs), 
                new Card(CardFace.Ace, Suit.Diamonds),
                new Card(CardFace.Ace, Suit.Hearts),
            });

            var player = new PlayerImplementation(testDeck);
            player.PlayTurn();

            Assert.AreEqual(13, player.HandValue());
        }
        
        [Test]
        public void AceChangesValue()
        {
            var testDeck = new TestDeck(new[]
            {
                new Card(CardFace.Ace, Suit.Clubs), 
                new Card(CardFace.Ace, Suit.Diamonds),
                new Card(CardFace.Five, Suit.Hearts),
                new Card(CardFace.Five, Suit.Hearts),
                
            });

            var player = new PlayerImplementation(testDeck);
            player.PlayTurn();
            player.PlayTurn();

            Assert.AreEqual(12, player.HandValue());
        }
        
        
        private class PlayerImplementation:Player
        {
            public PlayerImplementation(IDeck deck) : base(deck)
            {
            }

            public override void PlayTurn()
            {
                DrawCard();
            }
        }
    }
}