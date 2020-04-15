


namespace kata_blackjack
{
    public class Human : Player
    
    {
        public override int MaxPlayerHandValue { get; } = 18;


        public Human(IDeck deck) : base(deck)
        {
           
        }
        
       

    }
}