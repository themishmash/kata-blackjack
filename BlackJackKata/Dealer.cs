
namespace kata_blackjack
{
    public class Dealer : Player
    {
        public override int MaxPlayerHandValue { get; } = 17;

        public Dealer(IDeck deck) : base(deck)
        {
            
          
        }
        
        
       
    }
}