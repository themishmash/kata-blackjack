using System.Collections.Generic;
using kata_blackjack;
using NUnit.Framework;

namespace blackjackTests
{
    public class Tests
    {
        private const string StayInput = "0";
        private const string HitInput = "1";
        
        [SetUp]
        public void Setup()
        {
        }
        


        [Test]
         public void Soft17PlayerWin()
         {
             var testDeck = new TestDeck(new[]
             {
                 new Card(CardFace.Eight, Suit.Hearts),
                 new Card(CardFace.Eight, Suit.Diamonds),
                 new Card(CardFace.Ten, Suit.Spades), 
                 new Card(CardFace.Seven, Suit.Diamonds),
                 new Card(CardFace.Ace, Suit.Hearts), 
             });
             var testQuestionResponse = new TestResponder(StayInput);
             var human = new Human(testDeck, testQuestionResponse);
             var soft17Player = new Soft17Player(testDeck);
             var blackjack = new BlackJack(new List<Player> {human}, soft17Player);
             
             //human.PlayTurn();
             
             //Assert.AreEqual(16, human.HandValue());
             Assert.AreEqual(false, blackjack.PlayerHasWon(human));
         }
         
         [Test]
         public void HumanWin()
         {
             var testDeck = new TestDeck(new[]
             {
                 new Card(CardFace.Jack, Suit.Hearts), //Human
                 new Card(CardFace.Six, Suit.Spades), //Human
                 new Card(CardFace.Jack, Suit.Diamonds), //Soft17Player
                 new Card(CardFace.Seven, Suit.Spades), //Soft17Player
                 new Card(CardFace.Two, Suit.Diamonds), //Human
                 new Card(CardFace.Ace, Suit.Hearts), 
             });
             var testQuestionResponse = new TestResponder( new[]
             {
                 HitInput,
                 HitInput,
                 StayInput
             });
             var human = new Human(testDeck, testQuestionResponse);
             var soft17Player = new Soft17Player(testDeck);
             var blackjack = new BlackJack(new List<Player> {human}, soft17Player);
             
             human.PlayTurn();

             //Assert.AreEqual(18, human.HandValue());
             Assert.AreEqual(true, blackjack.PlayerHasWon(human));
         }
         
         [Test]
         public void Soft17PlayerBusts()
         {
             var testDeck = new TestDeck(new[]
             {
                 new Card(CardFace.Jack, Suit.Hearts),
                 new Card(CardFace.Six, Suit.Spades),
                 new Card(CardFace.Jack, Suit.Diamonds),
                 new Card(CardFace.Eight, Suit.Spades), 
                 new Card(CardFace.Nine, Suit.Diamonds),
                 new Card(CardFace.Ace, Suit.Hearts), 
             });
             var testQuestionResponse = new TestResponder(StayInput);
             var human = new Human(testDeck, testQuestionResponse);
             var dealer = new Soft17Player(testDeck);
             var blackjack = new BlackJack(new List<Player> {human}, dealer);
            
            blackjack.StartGame();
            
             Assert.AreEqual(25, dealer.HandValue());
             Assert.AreEqual(true, blackjack.PlayerHasWon(human));
             Assert.AreEqual(true, BlackJack.HasBusted(dealer));
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
            var testQuestionResponse = new TestResponder(new[]
            {
                HitInput,
                HitInput,
                HitInput,
                StayInput
            });
            var human = new Human(testDeck, testQuestionResponse);
            var players = new List<Player> {human};
            var dealer = new Soft17Player(testDeck);
            var blackjack = new BlackJack(players, dealer);

            //blackjack.StartGame();
            human.PlayTurn();
            
            Assert.AreEqual(28, human.HandValue());
            Assert.AreEqual(false, blackjack.PlayerHasWon(human));
            Assert.AreEqual(true, BlackJack.HasBusted(human));
        }

        [Test]
        public void ValueOfAceAsOne()
        {
            var testDeck = new TestDeck(new[]
            {
                // new Card(CardFace.Jack, Suit.Hearts),
                // new Card(CardFace.Eight, Suit.Spades),
                new Card(CardFace.Jack, Suit.Diamonds),
                new Card(CardFace.Three, Suit.Spades), 
                new Card(CardFace.Ace, Suit.Diamonds),
                new Card(CardFace.Ace, Suit.Hearts), 
            });
            var testQuestionResponse = new TestResponder( new[]
            {
                HitInput,
                HitInput,
                HitInput,
                StayInput, 
            });
            var human = new Human(testDeck, testQuestionResponse);
            var soft17Player = new Soft17Player(testDeck);
            var blackjack = new BlackJack(new List<Player> {human}, soft17Player);
            
            //blackjack.StartGame();
            human.PlayTurn();
            
            Assert.AreEqual(14, human.HandValue());
            //Assert.AreEqual(false, blackjack.HumanHasWon());
            //Assert.AreEqual(true, blackjack.IsBust());
        }
        
        
        [Test]

        public void CreateMultiplePlayersShownByDecreaseInDeckCards()
        {
            var testDeck = new TestDeck(new[]
            {
                new Card(CardFace.Jack, Suit.Hearts),
                new Card(CardFace.Eight, Suit.Spades),
                new Card(CardFace.Jack, Suit.Diamonds),
                new Card(CardFace.Three, Suit.Spades), 
                new Card(CardFace.Ace, Suit.Diamonds),
                new Card(CardFace.Ace, Suit.Hearts), 
                new Card(CardFace.Jack, Suit.Hearts),
                new Card(CardFace.Eight, Suit.Spades),
                new Card(CardFace.Jack, Suit.Diamonds),

            });
            
            var testQuestionResponse1 = new TestResponder(StayInput);
            var testQuestionResponse2 = new TestResponder(StayInput);

            var players = new List<Player>()
            {
                new Human(testDeck, testQuestionResponse1),
                new Human(testDeck, testQuestionResponse2),
            };
           
            var dealer = new Soft17Player(testDeck);
            var blackjack = new BlackJack(players, dealer);
            
            blackjack.StartGame();
            
            Assert.AreEqual(3, testDeck._testCards.Count);
           // Assert.AreEqual(2, blackjack._playerList.Count); don't change class to be public just to get test to pass!
        }

        [Test]
        public void DealerPlayTurnAfterAllPlayersPlayTurn()
        {
            var testDeck = new TestDeck(new[]
            {
                new Card(CardFace.Jack, Suit.Hearts),
                new Card(CardFace.Two, Suit.Spades),
                new Card(CardFace.Jack, Suit.Diamonds),
                new Card(CardFace.Five, Suit.Spades), 
                new Card(CardFace.Three, Suit.Diamonds),
                new Card(CardFace.Nine, Suit.Hearts), 
                new Card(CardFace.Seven, Suit.Hearts),
                new Card(CardFace.Eight, Suit.Spades),
                new Card(CardFace.Jack, Suit.Diamonds),

            });
            
            var testQuestionResponse1 = new TestResponder(new[]
            {
                HitInput,
                StayInput,
            });
            var testQuestionResponse2 = new TestResponder(StayInput);

            var players = new List<Player>()
            {
                new Human(testDeck, testQuestionResponse1),
                new Human(testDeck, testQuestionResponse2),
            };
           
            var dealer = new Soft17Player(testDeck);
            var blackjack = new BlackJack(players, dealer);
            
            blackjack.StartGame();

            Assert.AreEqual(20, dealer.HandValue());
            //Assert.AreEqual(22, players[0].HandValue());
        }
        
    }
}