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
        

        // [Test]
        // public void CheckIsBustedReturnTrueForScoreOver21()
        // {
        //     var testDeck = new TestDeck(new []
        //     {
        //         new Card(CardFace.Nine, Suit.Diamonds),
        //         new Card(CardFace.Five, Suit.Spades), 
        //         new Card(CardFace.Eight, Suit.Hearts),
        //        
        //     });
        //     
        //     var human = new Human(testDeck);
        //     var dealer = new Dealer(testDeck);
        //     var blackjack = new BlackJack(dealer, human);
        //     
        //     dealer.PlayTurn();
        //     
        //     Assert.AreEqual(true, blackjack.IsBust());
        // }

        // [Test]
        // public void CheckIfPlayerScoreIs21()
        // {
        //     var testDeck = new TestDeck(new []
        //     {
        //         new Card(CardFace.King, Suit.Hearts), 
        //         new Card(CardFace.Three, Suit.Spades), 
        //         new Card(CardFace.Eight, Suit.Diamonds),
        //        
        //     });
        //     
        //     var human = new Human(testDeck);
        //     var dealer = new Dealer(testDeck);
        //     var blackjack = new BlackJack(dealer, human);
        //     
        //    dealer.PlayTurn();
        //     
        //     Assert.AreEqual(true, blackjack.HasScore21());
        // }

        // [Test]
        // public void HumanStayAndLoses()
        // {
        //     var testDeck = new TestDeck(new[]
        //     {
        //         new Card(CardFace.Eight, Suit.Hearts),
        //         new Card(CardFace.Eight, Suit.Diamonds),
        //         new Card(CardFace.Three, Suit.Spades), 
        //         new Card(CardFace.Eight, Suit.Diamonds),
        //     });
        //     
        //     var human = new Human(testDeck);
        //     var dealer = new Dealer(testDeck);
        //     var blackjack = new BlackJack(dealer, human);
        //     
        //     human.PlayTurn();
        //     
        //     Assert.AreEqual(false, blackjack.PlayerHasWon());
        // }

        // [Test]
        // public void HumanHitsAndBustsAndDealerWins()
        // {
        //     var testDeck = new TestDeck(new[]
        //     {
        //         new Card(CardFace.Jack, Suit.Hearts),
        //         new Card(CardFace.Eight, Suit.Spades),
        //         new Card(CardFace.Jack, Suit.Diamonds),
        //         new Card(CardFace.Three, Suit.Spades), 
        //         new Card(CardFace.Nine, Suit.Diamonds),
        //     });
        //     
        //     var human = new Human(testDeck);
        //     var dealer = new Dealer(testDeck);
        //     var blackjack = new BlackJack(dealer, human);
        //     
        //     human.PlayTurn();
        //     
        //     Assert.AreEqual(false, blackjack.PlayerHasWon());
        // }
        //
        
    }
}