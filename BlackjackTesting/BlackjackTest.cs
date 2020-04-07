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

            Assert.AreEqual(1, deck.CardList.Count(c => c.CardFace == CardFace.Ace && c.Suit == Suit.Clubs));
        }

        [Test]
        public void Deck_dealOneCardAndRemoveFromDeck()
        {
            var deck = new Deck();
            
            var cardDrawn = deck.DrawOneCardFromDeck();

            Assert.AreEqual(51, deck.NumberOfCards());
            Assert.IsFalse(deck.CardList.Contains(cardDrawn)); //Windy helped with this
        }

    
        
        [Test]
        public void Deck_dealDifferentCardWithEachCardDrawnDuringSameGame()
        {
            var deck = new Deck();

            var card1 = deck.DrawOneCardFromDeck();
            var card2 = deck.DrawOneCardFromDeck();

            Assert.AreNotEqual(card1, card2);
        }
        
        [Test]
        public void Deck_cannotDrawMoreCardsWhenThereAreNoMoreCardsLeft()
        {
            var deck = new Deck();

            while (deck.CardList.Count > 0)
            {
                deck.DrawOneCardFromDeck();
            }

            var card = deck.DrawOneCardFromDeck();

            Assert.IsNull(card);
        }

        [Test]
        public void Dealer_dealOneCardAndCheckNumberOfCardsInHand()
        {
            var deck = new Deck();
            var dealer = new Dealer();
            dealer.AddOneCardToDealerHand(deck);
  
            Assert.AreEqual(1, dealer.NumberOfDealerCards());
        }
        
        [Test]
        public void Human_dealOneCardAndCheckNumberOfCardsInHand()
        {
            var deck = new Deck();
            var human = new Human(deck);
            human.AddOneCardToHand();
  
            Assert.AreEqual(1, human.NumberOfHumanCards());
        }

        [Test]
        public void Human_scoreOfCards() //trying to check score of hand
        {
            //Given
            var testDeck = new TestDeck();
            var human = new Human(testDeck);
            
            //When
            human.AddOneCardToHand();
            human.AddOneCardToHand();

            //Then
            Assert.AreEqual(16, human.CardTotalValue());
        }
        
    }
}