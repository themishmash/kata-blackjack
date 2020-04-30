using kata_blackjack;
using NUnit.Framework;

namespace blackjackTests
{
    public class HumanTests
    {
        private const string StayInput = "0";
        private const string HitInput = "1";

        [Test]
        public void PlayerStartsWithTwoCards()
        {
            //Given
            var testDeck = new TestDeck((new []
            {
                new Card(CardFace.Eight, Suit.Clubs), 
                new Card(CardFace.Eight, Suit.Diamonds),
                new Card(CardFace.Five, Suit.Clubs), 
                
            }));
            var testQuestionResponse = new TestResponder(StayInput);
            var human = new Human(testDeck, testQuestionResponse);
            human.PlayTurn(); //don't need this
            
            //When

            //Then
            Assert.AreEqual(16, human.HandValue());
        }
        
        [Test]
        public void PlayerCanHit()
        {
            var testDeck = new TestDeck(new[]
            {
                new Card(CardFace.Eight, Suit.Clubs), 
                new Card(CardFace.Eight, Suit.Diamonds),
                new Card(CardFace.Five, Suit.Clubs), 
            });
            var testQuestionResponse = new TestResponder(HitInput);
            var human = new Human(testDeck, testQuestionResponse);
            
            human.PlayTurn();

            Assert.AreEqual(21, human.HandValue());

        }
        
        [Test]
        public void PlayerCantHitAt21()
        {
            var testDeck = new TestDeck(new[]
            {
                new Card(CardFace.Eight, Suit.Clubs), 
                new Card(CardFace.Eight, Suit.Diamonds),
                new Card(CardFace.Five, Suit.Clubs), 
                new Card(CardFace.Seven, Suit.Diamonds), 
            });
            var testQuestionResponse = new TestResponder(HitInput);
            var human = new Human(testDeck, testQuestionResponse);
            
            human.PlayTurn();

            Assert.AreEqual(21, human.HandValue());

        }
        
        [Test]
        public void PlayerCanHitAt20()
        {
            var testDeck = new TestDeck(new[]
            {
                new Card(CardFace.Ten, Suit.Clubs), 
                new Card(CardFace.Ten, Suit.Diamonds),
                new Card(CardFace.Five, Suit.Clubs),
            });
            var testQuestionResponse = new TestResponder(HitInput);
            var human = new Human(testDeck, testQuestionResponse);
            
            human.PlayTurn();

            Assert.AreEqual(25, human.HandValue());

        }
        
        [Test]
        public void PlayerCanStayWithTwoCards()
        {
            var testDeck = new TestDeck(new[]
            {
                new Card(CardFace.Ten, Suit.Clubs), 
                new Card(CardFace.Ten, Suit.Diamonds),
                new Card(CardFace.Five, Suit.Clubs),
            });
            var testQuestionResponse = new TestResponder(StayInput); //put in () "0"
            var human = new Human(testDeck, testQuestionResponse);
            
            human.PlayTurn();

            Assert.AreEqual(20, human.HandValue());
        }
        
        [Test]//not working. look at Testdeck for inspiration - need two constructors in TestInput. Need similar methods from TestDeck
        public void PlayerCanHitAndThenStay()
        {
            var testDeck = new TestDeck(new[]
            {
                new Card(CardFace.Ten, Suit.Clubs), 
                new Card(CardFace.Five, Suit.Diamonds),
                new Card(CardFace.Three, Suit.Clubs),
                new Card(CardFace.Ace, Suit.Clubs), 
            });
            var testQuestionResponse = new TestResponder( new[]
            {
                HitInput,
               StayInput, 
            }); //put in () "0"
            var human = new Human(testDeck, testQuestionResponse);
            
            human.PlayTurn();

            Assert.AreEqual(18, human.HandValue());
        }
        
        
        [Test]//not working. look at Testdeck for inspiration - need two constructors in TestInput. Need similar methods from TestDeck
        public void AceCanBeEleven()
        {
            var testDeck = new TestDeck(new[]
            {
                new Card(CardFace.Six, Suit.Clubs), 
                new Card(CardFace.Ace, Suit.Diamonds),
                new Card(CardFace.Two, Suit.Clubs),
                new Card(CardFace.Ace, Suit.Clubs), 
                new Card(CardFace.Five, Suit.Clubs), 
            });
            var testQuestionResponse = new TestResponder( new[]
            {
                HitInput,
                HitInput,
                StayInput, 
            }); //put in () "0"
            var human = new Human(testDeck, testQuestionResponse);
            
            human.PlayTurn();

            Assert.AreEqual(20, human.HandValue());
        }
        
        
        
        
    }
}