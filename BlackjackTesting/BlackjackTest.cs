using System.Linq;
using kata_blackjack;
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
            Assert.AreEqual(52, deck.TotalNumberOfCardsInCardList());
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

            Assert.AreEqual(51, deck.TotalNumberOfCardsInCardList());
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
            var dealer = new Dealer(deck);
            dealer.AddOneCardToHand();
  
            Assert.AreEqual(1, dealer.TotalNumberOfCardsInPlayerHand());
        }
        
        [Test]
        public void Human_dealOneCardAndCheckNumberOfCardsInHand()
        {
            var deck = new Deck();
            var human = new Human(deck);
            human.AddOneCardToHand();
  
            Assert.AreEqual(1, human.TotalNumberOfCardsInPlayerHand());
        }

        [Test]
        public void Human_scoreOfCards() //trying to check score of hand
        {
            //Given
            var testDeck = new TestDeck((new []
            {
                new Card(CardFace.Eight, Suit.Clubs), 
                new Card(CardFace.Eight, Suit.Diamonds)
                
            }));
            var human = new Human(testDeck);
            
            //When
            human.AddOneCardToHand();
            human.AddOneCardToHand();

            //Then
            Assert.AreEqual(16, human.CardTotalValue());
        }

        [Test]
        public void BlackJack_hitCardCheckTotalNumberOfCardsInDealerHand()
        {
            var deck = new Deck();
            var human = new Human(deck);
            var dealer = new Dealer(deck);
            var blackjack = new BlackJack(dealer, human);
            
           // blackjack.StartGame();
            blackjack.HitCard(dealer);
            
            Assert.AreEqual(1, dealer.TotalNumberOfCardsInPlayerHand());
        }
        
        [Test]
        public void BlackJack_dealerHitCardToValue17()
        {
            var testDeck = new TestDeck(new []
            {
                new Card(CardFace.Queen, Suit.Clubs), 
                new Card(CardFace.Seven, Suit.Diamonds)
                
            });
            var human = new Human(testDeck);
            var dealer = new Dealer(testDeck);
            var blackjack = new BlackJack(dealer, human);
            
            blackjack.HitCard(dealer);
            blackjack.HitCard(dealer);
            //blackjack.HitCard(dealer);
            
            Assert.AreEqual(17, dealer.CardTotalValue());
        }
        
    }
}