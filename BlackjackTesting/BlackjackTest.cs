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
            var deck = new Deck();
            Assert.AreEqual(52, deck.NumberOfCards());
        }

        [Test]
        public void Deck_deckContainsSpecificCards()
        {
            var deck = new Deck();

            Assert.AreEqual(1, deck._cardList.Count(c => c.CardFace == CardFace.Ace && c.Suit == Suit.Clubs));
        }

        [Test]
        public void Deck_dealOneCardAndRemoveFromDeck()
        {
            var deck = new Deck();
            
            deck.DrawOneCardFromDeck();

            Assert.AreEqual(51, deck.NumberOfCards());
        }
    }
}