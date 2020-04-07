using blackjack;

namespace blackjackTests
{
    public class TestDeck : IDeck
    {
        public TestDeck()
        {
           // CardList.Insert(0, new Card(CardFace.Eight, Suit.Diamonds));
           //could later return a list of cards in the order we specify here as no shuffling

        }


        public Card DrawOneCardFromDeck()
        {
            return new Card(CardFace.Eight, Suit.Diamonds);
        }
    }
}