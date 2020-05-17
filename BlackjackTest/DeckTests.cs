using System.Linq;
using kata_blackjack;
using NUnit.Framework;

namespace blackjackTests
{
    public class DeckTests
    {
        [Test]
        public void InitialiseDeckStartsWith52Cards()
        {
            var deck = new Deck();
            Assert.AreEqual(52, deck.CardsLeft());
        }

        [Test]
        public void ContainsSpecificCards()
        {
            var deck = new Deck();

            Assert.AreEqual(1, deck.CardList.Count(c => c.CardFace == CardFace.Ace && c.Suit == Suit.Clubs));
        }

        [Test]
        public void DealOneCardAndRemoveFromDeck()
        {
            var deck = new Deck();
            
            var cardDrawn = deck.DrawCard();

            Assert.AreEqual(51, deck.CardsLeft());
            Assert.IsFalse(deck.CardList.Contains(cardDrawn)); //Windy helped with this
        }
        
        [Test]
        public void DealDifferentCardWithEachCardDrawnDuringSameGame()
        {
            var deck = new Deck();

            var card1 = deck.DrawCard();
            var card2 = deck.DrawCard();

            Assert.AreNotEqual(card1, card2);
        }
        
        [Test]
        public void CannotDrawMoreCardsWhenThereAreNoMoreCardsLeft()
        {
            var deck = new Deck();

            while (deck.CardList.Count > 0)
            {
                deck.DrawCard();
            }

            var card = deck.DrawCard();

            Assert.IsNull(card);
        }


    }
}