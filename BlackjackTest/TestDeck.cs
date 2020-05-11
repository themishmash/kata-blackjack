using System.Collections.Generic;
using kata_blackjack;


namespace blackjackTests
{
    
    public class TestDeck : IDeck
    {

        public readonly Queue<Card> _testCards = new Queue<Card>();

        public TestDeck(IEnumerable<Card> testCards)
        {
            foreach (var testcard in testCards)
            {
                _testCards.Enqueue(testcard);
            }
        }

        public Card DrawCard()
        {
            return _testCards.Dequeue();
        }

        
        
        
        
    }
}