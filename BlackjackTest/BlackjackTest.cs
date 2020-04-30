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


        [Test]
         public void DealerWin()
         {
             var testDeck = new TestDeck(new[]
             {
                 new Card(CardFace.Eight, Suit.Hearts),
                 new Card(CardFace.Eight, Suit.Diamonds),
                 new Card(CardFace.Ten, Suit.Spades), 
                 new Card(CardFace.Seven, Suit.Diamonds),
                 new Card(CardFace.Ace, Suit.Hearts), 
             });
             var testQuestionResponse = new TestResponder("0");
             var human = new Human(testDeck, testQuestionResponse);
             var dealer = new Dealer(testDeck);
             var blackjack = new BlackJack(dealer, human);
             
             //human.PlayTurn();
             
             //Assert.AreEqual(16, human.HandValue());
             Assert.AreEqual(false, blackjack.HumanHasWon());
         }
         
         [Test] //failing
         public void HumanWin()
         {
             var testDeck = new TestDeck(new[]
             {
                 new Card(CardFace.Jack, Suit.Hearts), //Human
                 new Card(CardFace.Six, Suit.Spades), //Human
                 new Card(CardFace.Jack, Suit.Diamonds), //Dealer
                 new Card(CardFace.Seven, Suit.Spades), //Dealer
                 new Card(CardFace.Two, Suit.Diamonds), //Human
                 new Card(CardFace.Ace, Suit.Hearts), 
             });
             var testQuestionResponse = new TestResponder( new[]
             {
                 "1",
                 "1",
                 "0"
             });
             var human = new Human(testDeck, testQuestionResponse);
             var dealer = new Dealer(testDeck);
             var blackjack = new BlackJack(dealer, human);
             
             human.PlayTurn();

             //Assert.AreEqual(18, human.HandValue());
             Assert.AreEqual(true, blackjack.HumanHasWon());
         }
         
         [Test]
         public void DealerBusts()
         {
             var testDeck = new TestDeck(new[]
             {
                 new Card(CardFace.Jack, Suit.Hearts),
                 new Card(CardFace.Eight, Suit.Spades),
                 new Card(CardFace.Jack, Suit.Diamonds),
                 new Card(CardFace.Three, Suit.Spades), 
                 new Card(CardFace.Nine, Suit.Diamonds),
                 new Card(CardFace.Ace, Suit.Hearts), 
             });
             var testQuestionResponse = new TestResponder("0");
             var human = new Human(testDeck, testQuestionResponse);
             var dealer = new Dealer(testDeck);
             var blackjack = new BlackJack(dealer, human);
            
            dealer.PlayTurn();
            
             Assert.AreEqual(22, dealer.HandValue());
             Assert.AreEqual(false, blackjack.HumanHasWon());
             Assert.AreEqual(true, blackjack.IsBust());
         } 

        [Test]
        public void HumanHitsAndBusts()
        {
            var testDeck = new TestDeck(new[]
            {
                new Card(CardFace.Jack, Suit.Hearts),
                new Card(CardFace.Eight, Suit.Spades),
                new Card(CardFace.Jack, Suit.Diamonds),
                new Card(CardFace.Three, Suit.Spades), 
                new Card(CardFace.Nine, Suit.Diamonds),
                new Card(CardFace.Ace, Suit.Hearts), 
            });
            var testQuestionResponse = new TestResponder("1");
            var human = new Human(testDeck, testQuestionResponse);
            var dealer = new Dealer(testDeck);
            var blackjack = new BlackJack(dealer, human);
            
            human.PlayTurn();
            
            Assert.AreEqual(27, human.HandValue());
            Assert.AreEqual(false, blackjack.HumanHasWon());
            Assert.AreEqual(true, blackjack.IsBust());
        }

        [Test]
        public void ValueOfAceAsOne()
        {
            var testDeck = new TestDeck(new[]
            {
                new Card(CardFace.Jack, Suit.Hearts),
                new Card(CardFace.Eight, Suit.Spades),
                new Card(CardFace.Jack, Suit.Diamonds),
                new Card(CardFace.Three, Suit.Spades), 
                new Card(CardFace.Ace, Suit.Diamonds),
                new Card(CardFace.Ace, Suit.Hearts), 
            });
            var testQuestionResponse = new TestResponder( new[]
            {
                "1",
                "0", 
            });
            var human = new Human(testDeck, testQuestionResponse);
            var dealer = new Dealer(testDeck);
            var blackjack = new BlackJack(dealer, human);
            
            human.PlayTurn();
            
            Assert.AreEqual(19, human.HandValue());
            //Assert.AreEqual(false, blackjack.HumanHasWon());
            //Assert.AreEqual(true, blackjack.IsBust());
        }
        
        
    }
}