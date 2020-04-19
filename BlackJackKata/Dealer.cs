
namespace kata_blackjack
{
    public class Dealer : Player
    {
        protected override int MaxPlayerHandValue { get; } = 17;

        public Dealer(IDeck deck) : base(deck)
        {
            DrawCard();
            DrawCard();
          
        }

        public override void PlayTurn()
        {
            while (HandValue() < MaxPlayerHandValue)
            {
                DrawCard();
            }
            
        }
        
        
        
       
    }
}