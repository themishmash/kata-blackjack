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
        public void Deck_InitialiseDeckStartsWith52Cards()
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
            
            var cardDrawn = deck.DrawCard();

            Assert.AreEqual(51, deck.TotalNumberOfCardsInCardList());
            Assert.IsFalse(deck.CardList.Contains(cardDrawn)); //Windy helped with this
        }

    
        
        [Test]
        public void Deck_dealDifferentCardWithEachCardDrawnDuringSameGame()
        {
            var deck = new Deck();

            var card1 = deck.DrawCard();
            var card2 = deck.DrawCard();

            Assert.AreNotEqual(card1, card2);
        }
        
        [Test]
        public void Deck_cannotDrawMoreCardsWhenThereAreNoMoreCardsLeft()
        {
            var deck = new Deck();

            while (deck.CardList.Count > 0)
            {
                deck.DrawCard();
            }

            var card = deck.DrawCard();

            Assert.IsNull(card);
        }

        
        

        [Test]
        public void Human_scoreOfCards() 
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
        
        
        [Test]
        public void Player_dealerCannotHitCardAndAddValueToScore17()
        {
            var testDeck = new TestDeck(new []
            {
               
                new Card(CardFace.Queen, Suit.Clubs), 
                new Card(CardFace.Seven, Suit.Diamonds),
                new Card(CardFace.Four, Suit.Spades), 
               
                
            });
        
            var dealer = new Dealer(testDeck);

            dealer.PlayTurn();

            Assert.AreEqual(17, dealer.HandValue());
        }

        

        [Test]
        public void BlackJack_checkIsBustedReturnTrueForScoreOver21()
        {
            var testDeck = new TestDeck(new []
            {
                new Card(CardFace.Nine, Suit.Diamonds),
                new Card(CardFace.Five, Suit.Spades), 
                new Card(CardFace.Eight, Suit.Hearts),
               
            });
            
            var human = new Human(testDeck);
            var dealer = new Dealer(testDeck);
            var blackjack = new BlackJack(dealer, human);
            
            dealer.PlayTurn();
            
            Assert.AreEqual(true, blackjack.IsBust());
        }

        [Test]
        public void BlackJack_CheckIfPlayerScoreIs21()
        {
            var testDeck = new TestDeck(new []
            {
                new Card(CardFace.King, Suit.Hearts), 
                new Card(CardFace.Three, Suit.Spades), 
                new Card(CardFace.Eight, Suit.Diamonds),
               
            });
            
            var human = new Human(testDeck);
            var dealer = new Dealer(testDeck);
            var blackjack = new BlackJack(dealer, human);
            
           dealer.PlayTurn();
            
            Assert.AreEqual(true, blackjack.HasScore21());
        }

        [Test]
        public void BlackJack_HumanStayAndLoses()
        {
            var testDeck = new TestDeck(new[]
            {
                new Card(CardFace.Eight, Suit.Hearts),
                new Card(CardFace.Eight, Suit.Diamonds),
                new Card(CardFace.Three, Suit.Spades), 
                new Card(CardFace.Eight, Suit.Diamonds),
            });
            
            var human = new Human(testDeck);
            var dealer = new Dealer(testDeck);
            var blackjack = new BlackJack(dealer, human);
            
            human.PlayTurn();
            
            Assert.AreEqual(false, blackjack.PlayerHasWon());
        }

        [Test]
        public void BlackJack_HumanHitsAndBustsAndDealerWins()
        {
            var testDeck = new TestDeck(new[]
            {
                new Card(CardFace.Jack, Suit.Hearts),
                new Card(CardFace.Eight, Suit.Spades),
                new Card(CardFace.Jack, Suit.Diamonds),
                new Card(CardFace.Three, Suit.Spades), 
                new Card(CardFace.Nine, Suit.Diamonds),
            });
            
            var human = new Human(testDeck);
            var dealer = new Dealer(testDeck);
            var blackjack = new BlackJack(dealer, human);
            
            human.PlayTurn();
            
            Assert.AreEqual(false, blackjack.PlayerHasWon());
        }
        
        
    }
}