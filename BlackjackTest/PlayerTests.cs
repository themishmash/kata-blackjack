using kata_blackjack;
using NUnit.Framework;

namespace blackjackTests
{
    public class PlayerTests
    {
        
        [Test]//not working. look at Testdeck for inspiration - need two constructors in TestInput. Need similar methods from TestDeck
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