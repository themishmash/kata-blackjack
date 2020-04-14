using kata_blackjack;

namespace blackjackTests
{
    public class TestDeck : IDeck
    {
      


        public Card DrawOneCardFromDeck()
        {
            return new Card(CardFace.Eight, Suit.Diamonds);
        }
        
        
    }
}