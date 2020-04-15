using System;

namespace kata_blackjack
{
    public class BlackJack
    {
        //assign properties dealer and human 
        //get them to draw two cards
        
        
        //hit card
        //make human player stay on 18 for now
        //have logic dealer stays on 17

        private Dealer _dealer;
        private Human _human;
        
        
        public BlackJack(Dealer dealer, Human human)
        {
          
            _dealer = dealer;
            _human = human;
            //_deck = deck;
            
        }
        public void StartGame()
        {
            
            //draw two cards.
            _dealer.AddOneCardToHand();
            _dealer.AddOneCardToHand();

            _human.AddOneCardToHand();
            _human.AddOneCardToHand();

        }

        public void HitCard(Player player)
        {
            
            
            // if (_dealer.CardTotalValue() < 17)
            // {
            //     _dealer.AddOneCardToHand();
            // }
            // else
            // {
            //     Console.WriteLine("you can't hit anymore");
            //     
            // }

            if (player.CardTotalValue() < player.MaxPlayerHandValue)
            {
                player.AddOneCardToHand();
            }

            //Console.WriteLine($"You are on {dealer.CardTotalValue()}");
        }

        // public void HitCardHuman()
        // {
        //     if (_human.CardTotalValue() < 18)
        //     {
        //         _human.AddOneCardToHand();
        //     }
        //     else
        //     {
        //         Console.WriteLine("You can't hit anymore");
        //     }
        //     
        // }
        
        public bool IsBust ()
        {
            if (_human.CardTotalValue() > 21 || _dealer.CardTotalValue() > 21)
                return true;
            return false;
        }

        
        
        
    }
}