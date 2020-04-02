namespace blackjack
{
    public class Card
    {
        public CardFace CardFace;
        public Suit Suit;
        public int Value;
        
        public Card(CardFace cardFace, Suit suit)
        {
            CardFace = cardFace;
            Suit = suit;
            Value = (int) cardFace + 1;
            if (Value > 10) Value = 10;
        }
    }
}