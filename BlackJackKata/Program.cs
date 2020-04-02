using System;

namespace blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Deck deck = new Deck();
            deck.CreateDeck();
            deck.PrintDeck();
        }
    }
}