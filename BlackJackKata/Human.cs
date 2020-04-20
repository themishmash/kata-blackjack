


namespace kata_blackjack
{
    public class Human : Player
    
    {
       // protected override int MaxPlayerHandValue { get; } = 18;

       // public bool HitCard { get; set; }

       private readonly IInputOutput _iio;

       public Human(IDeck deck, IInputOutput iio) : base(deck)
       {
           _iio = iio;
       }
        
        
        public override void PlayTurn()
        {
            while (true)
            {
                _iio.Output($"Your hand value is currently {HandValue()}");
                if (HandValue() < 21 && _iio.AskQuestion("Do you want to hit card?") == "y")
                {
                    DrawCard();
                }//make a const for 21 number. 
                else
                {
                  
                    return;
                }
            }
            
           
        }
        
        
        
       

    }
}