

using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_blackjack
{
    public class BlackJack
    {
        
        private readonly Player _dealer;
        private Player _human;
        private readonly List<Player> _playerList;
       

        public BlackJack(List<Player> players, Player dealer)
        {
            _playerList = players;
            _dealer = dealer;
            for (var i = 0; i < _playerList.Count; i++)
            {
                Console.WriteLine($"Player:{i + 1}");
            }
          
        }

        public BlackJack(Player dealer, Player human)
        {
          
            _dealer = dealer;
            _human = human;
            
        }
        
        

        public void StartGame()
        {

            var human = _playerList.First();

            
            // foreach (var human in _playerList)
            // {
            //     _human = human;
            //     _human.PlayTurn();
            // }

            human.PlayTurn();
          
             if (HasBusted(human))
             {
                 Console.WriteLine("Player has busted");
                 return;
             }
             if (HasBlackJack(human))
             {
                 Console.WriteLine("Player wins with BlackJack");
                 return;
             }
             _dealer.PlayTurn();
             if (PlayerHasWon(human))
             {
                 Console.WriteLine($"Player wins with {human.HandValue()} and dealer has score of {_dealer.HandValue()}");
                 return;
             }
            
             Console.WriteLine($"Dealer wins with score of {_dealer.HandValue()} and player has score of {human.HandValue()}");
            
        }


        public static bool HasBusted (Player player)
        {
            return player.HandValue() > 21;
        }
        
        // public bool HasWon()
        private static bool HasBlackJack(Player player)
        {
            return player.HandValue() == 21;
        }


        public bool PlayerHasWon(Player player)
        {
            return player.HandValue() > _dealer.HandValue() && !HasBusted(player) && !HasBusted(_dealer) || HasBusted(_dealer);
        }
    }
}