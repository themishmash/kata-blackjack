using System;

namespace kata_blackjack
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var deck = new Deck();
            var dealer = new Dealer(deck);
            var human = new Human(deck);
            var blackjack = new BlackJack(dealer, human);
            
            blackjack.StartGame();
            Console.WriteLine(human.HandValue());
            Console.WriteLine("Do you want to hit card?");
            string input = Console.ReadLine();

            if (input == "Y")
            {
                human.PlayTurn();
            }
            else
            {
                Console.WriteLine($"Your score is {human.HandValue()}");
            }

            Console.WriteLine(human.HandValue());


        }

    
     
    }
}