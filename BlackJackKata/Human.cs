


namespace kata_blackjack
{
    public class Human : Player
    
    {
       // protected override int MaxPlayerHandValue { get; } = 18;

       // public bool HitCard { get; set; }
       private const int WinningScore = 21;
       private readonly IInputOutput _iio; 

       public Human(IDeck deck, IInputOutput iio) : base(deck)
       {
           _iio = iio; 
       }
       
        public override void PlayTurn()
        {
            while (true)
            {
                _iio.Output($"Your are currently at {HandValue()}");
                if (HandValue() < WinningScore && _iio.AskQuestion("Hit or stay? (Hit = 1, Stay = 0)") == "1")
                {
                    
                    DrawCard();
                }
                else
                {
                    return;
                }
            }
        }
        
        
        
       

    }
}