﻿using System;

namespace blackjack
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var deck = new Deck();
            deck.CreateDeck();
            deck.PrintDeck();
        }
    }
}