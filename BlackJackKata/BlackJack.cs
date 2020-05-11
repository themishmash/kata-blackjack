using System;
using System.Collections.Generic;

namespace kata_blackjack
{
    public class BlackJack
    {
        private readonly Player _dealer;
       // private readonly Player _human;
        
        private readonly IList<Player> _playerList;
        //public ICollection<Player> _playerList;


        public BlackJack(IList<Player> players, Player dealer)
        {
           
            _playerList = players;
            _dealer = dealer;
            for (var i = 0; i < _playerList.Count; i++)
            {
                Console.WriteLine($"Player:{i + 1}");
            }
        }


        public void StartGame()
        {
            //var human = _playerList.First();
            _dealer.NewHand();
            foreach (var player in _playerList)
            {
                player.NewHand();
            }

            var i = 0;
            foreach (var human in _playerList)
            {
                human.PlayTurn();
                i++;
                if (HasBusted(human))
                {
                    Console.WriteLine($"Player {i} has busted");
                    continue; //continue instead of return so go to another player
                }
                
                if (HasBlackJack(human))
                {
                    Console.WriteLine($"Player {i} wins with BlackJack");
                    continue;
                }

                
                _dealer.PlayTurn();
                // if (PlayerHasWon(human))
                // {
                //     Console.WriteLine(
                //         $"Player wins with {human.HandValue()} and dealer has score of {_dealer.HandValue()}");
                //     continue;
                // }
                //
                // Console.WriteLine(
                //     $"Dealer wins with score of {_dealer.HandValue()} and player has score of {human.HandValue()}");

                
            }

            Console.WriteLine(_dealer.HandValue());
            
            foreach (var player in _playerList)
            {
                var index = _playerList.IndexOf(player) + 1;
                if (PlayerHasWon(player))
                {
                    
                    Console.WriteLine($"Player {index} wins against the dealer");
                }
                else
                {
                    Console.WriteLine($"Player {index} loses against the dealer");
                }
            }


            //human.PlayTurn();
        }


        public static bool HasBusted(Player player)
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
            return player.HandValue() > _dealer.HandValue() && !HasBusted(player) && !HasBusted(_dealer) ||
                   HasBusted(_dealer);
        }
    }
}