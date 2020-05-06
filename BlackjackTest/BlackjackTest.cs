using System.Collections.Generic;
using System.Linq;
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
             var blackjack = new BlackJack(soft17Player, human);
             
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
             var blackjack = new BlackJack(soft17Player, human);
             
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
                 new Card(CardFace.Eight, Suit.Spades),
                 new Card(CardFace.Jack, Suit.Diamonds),
                 new Card(CardFace.Three, Suit.Spades), 
                 new Card(CardFace.Nine, Suit.Diamonds),
                 new Card(CardFace.Ace, Suit.Hearts), 
             });
             var testQuestionResponse = new TestResponder(StayInput);
             var human = new Human(testDeck, testQuestionResponse);
             var soft17Player = new Soft17Player(testDeck);
             var blackjack = new BlackJack(soft17Player, human);
            
            soft17Player.PlayTurn();
            
             Assert.AreEqual(22, soft17Player.HandValue());
             Assert.AreEqual(true, blackjack.PlayerHasWon(human));
             Assert.AreEqual(true, BlackJack.HasBusted(soft17Player));
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
            var testQuestionResponse = new TestResponder(HitInput);
            var human = new Human(testDeck, testQuestionResponse);
            var soft17Player = new Soft17Player(testDeck);
            var blackjack = new BlackJack(soft17Player, human);
            
            human.PlayTurn();
            
            Assert.AreEqual(27, human.HandValue());
            Assert.AreEqual(false, blackjack.PlayerHasWon(human));
            Assert.AreEqual(true, BlackJack.HasBusted(human));
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
                HitInput,
                StayInput, 
            });
            var human = new Human(testDeck, testQuestionResponse);
            var soft17Player = new Soft17Player(testDeck);
            var blackjack = new BlackJack(soft17Player, human);
            
            human.PlayTurn();
            
            Assert.AreEqual(19, human.HandValue());
            //Assert.AreEqual(false, blackjack.HumanHasWon());
            //Assert.AreEqual(true, blackjack.IsBust());
        }

        [Test]

        public void CreateMultiplePlayers()
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
                new Card(CardFace.Three, Suit.Spades), 
             
            });
            var testQuestionResponse = new TestResponder( new[]
            {
                StayInput, 
            });

            var players = new List<Player>()
            {
                new Human(testDeck, testQuestionResponse),
                new Human(testDeck, testQuestionResponse),
                //new Human(testDeck, testQuestionResponse),
            };
           // var human = new Human(testDeck, testQuestionResponse);
            var soft17Player = new Soft17Player(testDeck);
            var blackjack = new BlackJack(players, soft17Player);
            
            //human.PlayTurn();
            
            blackjack.StartGame();
            
            //Assert.AreEqual(3, blackjack.NumberOfHumans.Count); //need to create property or method to work out number of humans
        }
        
    }
}