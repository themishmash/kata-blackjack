namespace kata_blackjack
{
    public class Card
    {
        public CardFace CardFace;
        public Suit Suit;
        public int ValueOfCardFace;

        private const int MaxValueOfCards = 10;

        public Card(CardFace cardFace, Suit suit)
        {
            CardFace = cardFace;
            Suit = suit;
            ValueOfCardFace = (int) cardFace + 1;
            if (ValueOfCardFace > MaxValueOfCards) ValueOfCardFace = MaxValueOfCards;
        }
    }
}