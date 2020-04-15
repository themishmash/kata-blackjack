using System;

namespace kata_blackjack
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var deck = new Deck();
            var dealer = new Dealer(deck);
            var human = new Human(deck);
            
            var blackJack = new BlackJack(dealer, human);
           
            //deck.CreateDeck();
            //deck.PrintDeck();
            
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            //deck.DrawOneCardFromDeck();
            //Console.WriteLine(deck.NumberOfCards());

            //deck.PrintDeck();

           
            // dealer.AddOneCardToDealerHand(deck);
            // dealer.PrintDealerHand();
           // Console.WriteLine(dealer.NumberOfDealerCards());
            // var card = new Card();
            //Console.WriteLine(dealer.CardTotalValue());
            
            //Testing after splitting into parent and child
         
            // human.AddOneCardToHand();
            // human.AddOneCardToHand();
            // human.AddOneCardToHand();
            // human.AddOneCardToHand();
            // Console.WriteLine(human.NumberOfPlayerCards());
            // human.PrintPlayerHand();
            
            
            
            blackJack.StartGame();
            //dealer.PrintPlayerHand();
            //human.PrintPlayerHand();
            blackJack.HitCard(dealer);
            blackJack.HitCard(dealer);
            blackJack.HitCard(dealer);
          
            dealer.PrintPlayerHand();
            Console.WriteLine(dealer.CardTotalValue());

            if (blackJack.IsBust())
            {
                Console.WriteLine("you are busted");
            }
           
            
            

        }
        
    }
}