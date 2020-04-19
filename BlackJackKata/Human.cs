


namespace kata_blackjack
{
    public class Human : Player
    
    {
        protected override int MaxPlayerHandValue { get; } = 18;


        public Human(IDeck deck) : base(deck)
        {
           
        }
        
        // public override void PlayTurn()
        // {
        //     HitCard();
        //     HitCard();
        //     HitCard();
        //     
        // }
        
        public override void PlayTurn()
        {
            // while (HandValue() < MaxPlayerHandValue)
            // {
            //     DrawCard();
            // }
            string input = "";

            if (input == "Y")
            {
                DrawCard();
            }
            
        }
        
       

    }
}