

namespace kata_blackjack
{
    public class BlackJack
    {
        
        private readonly Dealer _dealer;
        private readonly Human _human;
        
        
        public BlackJack(Dealer dealer, Human human)
        {
          
            _dealer = dealer;
            _human = human;

        }
        public void StartGame()
        {
            _human.DrawCard();
            _human.DrawCard();
            
            _dealer.DrawCard();
            _dealer.DrawCard();

        }


        public bool IsBust ()
        {
            return _human.HandValue() > 21 || _dealer.HandValue() > 21;
        }
        
        // public bool HasWon()
        public bool HasScore21()
        {
            return _human.HandValue() == 21 || _dealer.HandValue() == 21;
        }


        public bool PlayerHasWon()
        {
            return _human.HandValue() > _dealer.HandValue() && !IsBust() || HasScore21();
        }
    }
}