using System;

namespace blackjack
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var deck = new Deck();
            //deck.CreateDeck();
            //deck.PrintDeck();


            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            // deck.DrawOneCardFromDeck();
            //deck.DrawOneCardFromDeck();
            //Console.WriteLine(deck.NumberOfCards());

            //deck.PrintDeck();

            var dealer = new Dealer();
            dealer.AddOneCardToDealerHand(deck);
            dealer.PrintDealerHand();
            Console.WriteLine(dealer.NumberOfDealerCards());
            
        }
    }
}