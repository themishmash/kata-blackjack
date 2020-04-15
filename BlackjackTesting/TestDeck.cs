using System.Collections.Generic;
using System.Linq;
using kata_blackjack;


namespace blackjackTests
{
    public class TestDeck : IDeck
    {
        
        private readonly Stack<Card> TestCards = new Stack<Card>();
        // public TestDeck()
        // {
        //     TestCards.Push(new Card(CardFace.Eight, Suit.Clubs));
        //     
        // }

        public TestDeck(IEnumerable<Card> testCards)
        {
            foreach (var testcard in testCards)
            {
                TestCards.Push(testcard);
            }
        }

        public Card DrawOneCardFromDeck()
        {
            return TestCards.Pop();
        }
        
        
        
    }
}