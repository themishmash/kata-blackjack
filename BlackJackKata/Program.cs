using System;
using System.Collections.Generic;

namespace kata_blackjack
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var deck = new Deck();
            //var dealer = new Human(deck, new ConsoleInputOutput());
            var players = new List<Player>()
            {
                new Human(deck, new ConsoleInputOutput()){GameStatus = GameStatus.Playing},
                new Human(deck, new ConsoleInputOutput()){GameStatus = GameStatus.Playing},
                new Human(deck, new ConsoleInputOutput()){GameStatus = GameStatus.Playing},
                // new Human(deck, new ConsoleInputOutput()),
            };
            var dealer = new Soft17Player(deck){GameStatus = GameStatus.Playing};
            //var human = new Human(deck, new ConsoleInputOutput());
            var blackjack = new BlackJack(players, dealer);
            
            blackjack.StartGame();

            
       
        }

    
     
    }
}