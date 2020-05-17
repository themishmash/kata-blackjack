namespace kata_blackjack
{
    public interface IDeck
    {
        Card DrawCard();

        int CardsLeft();
    }
}