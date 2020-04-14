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
        private IDeck _deck;
        
        public BlackJack(Dealer dealer, Human human, IDeck deck)
        {
            // var deck = new Deck();
            // var dealer = new Dealer(deck);
            // var human = new Human(deck);
            _dealer = dealer;
            _human = human;
            _deck = deck;


        }
        public void StartGame()
        {
            
            //draw two cards.
            _dealer.AddOneCardToHand();
            _dealer.AddOneCardToHand();
            
            _human.AddOneCardToHand();
            _human.AddOneCardToHand();

        }

        public void HitCardDealer()
        {
            if (_dealer.CardTotalValue() < 17)
            {
                _dealer.AddOneCardToHand();
            }
            else
            {
                Console.WriteLine("you can't hit anymore");
                
            }

            //Console.WriteLine($"You are on {dealer.CardTotalValue()}");
        }

        public void HitCardHuman()
        {
            if (_human.CardTotalValue() < 18)
            {
                _human.AddOneCardToHand();
            }
            else
            {
                Console.WriteLine("You can't hit anymore");
            }
            
        }

        // public void WinMessage(Player player)
        // {
        //     if (player.CardTotalValue() == 21) 
        //         Console.WriteLine("BlackJack! Well done you have won the game!");
        //     
        // }

        // public void BustMessage(Player player)
        // {
        //     if (player.CardTotalValue()>21)
        //         Console.WriteLine("You have bust. You have gone over 21");
        // }
        
    }
}