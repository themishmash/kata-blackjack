using kata_blackjack;
using NUnit.Framework;

namespace blackjackTests
{
    public class HumanTests
    {
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
            var testQuestionResponse = new TestResponder("0");
            var human = new Human(testDeck, testQuestionResponse);
            
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
            var testQuestionResponse = new TestResponder("1");
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
            var testQuestionResponse = new TestResponder("1");
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
            var testQuestionResponse = new TestResponder("1");
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
            var testQuestionResponse = new TestResponder("0"); //put in () "0"
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
                "1",
               "0", 
            }); //put in () "0"
            var human = new Human(testDeck, testQuestionResponse);
            
            human.PlayTurn();

            Assert.AreEqual(18, human.HandValue());
        }
        
        
        
        
    }
}