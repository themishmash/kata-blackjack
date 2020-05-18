using kata_blackjack;
using NUnit.Framework;

namespace blackjackTests
{
    public class HumanTests
    {
        private const string StayInput = "0";
        private const string HitInput = "1";

        [Test]
        public void StartsWithTwoCards()
        {
            //Given
            var testDeck = new DeckMock((new []
            {
                new Card(CardFace.Eight, Suit.Clubs), 
                new Card(CardFace.Eight, Suit.Diamonds),
                new Card(CardFace.Five, Suit.Clubs), 
                
            }));
            var testQuestionResponse = new TestResponder(StayInput);
            var human = new Human(testDeck, testQuestionResponse);
            human.NewHand();

            //When

            //Then
            Assert.AreEqual(16, human.HandValue());
        }
        
        [Test]
        public void CanHit()
        {
            var testDeck = new DeckMock(new[]
            {
                new Card(CardFace.Eight, Suit.Clubs), 
                new Card(CardFace.Eight, Suit.Diamonds),
                new Card(CardFace.Five, Suit.Clubs), 
            });
            var testQuestionResponse = new TestResponder(HitInput);
            var human = new Human(testDeck, testQuestionResponse);
            
            human.NewHand();
            human.PlayTurn();

            Assert.AreEqual(21, human.HandValue());

        }
        
        [Test]
        public void CantHitAt21()
        {
            var testDeck = new DeckMock(new[]
            {
                new Card(CardFace.Eight, Suit.Clubs), 
                new Card(CardFace.Eight, Suit.Diamonds),
                new Card(CardFace.Five, Suit.Clubs), 
                new Card(CardFace.Seven, Suit.Diamonds), 
            });
            var testQuestionResponse = new TestResponder(HitInput);
            var human = new Human(testDeck, testQuestionResponse);
            
            human.NewHand();
            human.PlayTurn();

            Assert.AreEqual(21, human.HandValue());

        }
        
        [Test]
        public void CanHitAt20()
        {
            var testDeck = new DeckMock(new[]
            {
                new Card(CardFace.Ten, Suit.Clubs), 
                new Card(CardFace.Ten, Suit.Diamonds),
                new Card(CardFace.Five, Suit.Clubs),
            });
            var testQuestionResponse = new TestResponder(HitInput);
            var human = new Human(testDeck, testQuestionResponse);
            
            human.NewHand();
            human.PlayTurn();

            Assert.AreEqual(25, human.HandValue());

        }
        
        [Test]
        public void CanStayWithTwoCards()
        {
            var testDeck = new DeckMock(new[]
            {
                new Card(CardFace.Ten, Suit.Clubs), 
                new Card(CardFace.Ten, Suit.Diamonds),
                new Card(CardFace.Five, Suit.Clubs),
            });
            var testQuestionResponse = new TestResponder(StayInput); //put in () "0"
            var human = new Human(testDeck, testQuestionResponse);
            
            human.NewHand();
            human.PlayTurn();

            Assert.AreEqual(20, human.HandValue());
        }
        
        [Test]
        public void CanHitAndThenStay()
        {
            var testDeck = new DeckMock(new[]
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
            }); 
            var human = new Human(testDeck, testQuestionResponse);
            
            human.NewHand();
            human.PlayTurn();

            Assert.AreEqual(18, human.HandValue());
        }
        
    }
}