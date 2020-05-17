using System;
using System.Collections.Generic;

namespace kata_blackjack
{
    public class BlackJack
    {
        private readonly Player _dealer;
       // private readonly Player _human;
       
       private List<Player> WinningPlayer;
        
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
           WinningPlayer = new List<Player>();
            _dealer.NewHand();
            foreach (var player in _playerList)
            {
                player.NewHand();
            }

            var i = 0;
            foreach (var player in _playerList)
            {
                player.PlayTurn();
                i++;
                if (HasBusted(player))
                {
                    player.GameStatus = GameStatus.Busted;
                    Console.WriteLine($"Player {i} has busted");
                    continue; 
                }

                if (!HasBlackJack(player)) continue;
                player.GameStatus = GameStatus.BlackJack;
                Console.WriteLine($"Player {i} wins with BlackJack");
            }
            
            _dealer.PlayTurn();

            if (HasBusted(_dealer))
            {
                _dealer.GameStatus = GameStatus.Busted;
            }

            if (HasBlackJack(_dealer))
            {
                _dealer.GameStatus = GameStatus.BlackJack;
            }
            
            foreach (var player in _playerList)
            {
                if (HasBusted(player) || HasBlackJack(player)) continue;
                var index = _playerList.IndexOf(player) + 1;
                
                
                if (HasBeatenDealer(player))
                {
                    if (!HasBusted(_dealer))
                    {
                        _dealer.GameStatus = GameStatus.Lost;
                    }
                    player.GameStatus = GameStatus.Won;
                    Console.WriteLine($"Player {index} wins against the dealer");
                    WinningPlayer.Add(player);
                }
                else
                {
                    player.GameStatus = GameStatus.Lost;
                    _dealer.GameStatus = GameStatus.Won;
                    Console.WriteLine($"Player {index} loses against the dealer");
                    WinningPlayer.Add(_dealer);
                }

            }
            
        }


        private bool HasBusted(Player player)
        {
            return player.HandValue() > 21;
        }

        // public bool HasWon()
        private static bool HasBlackJack(Player player)
        {
            return player.HandValue() == 21;
        }


        private bool HasBeatenDealer(Player player)
        {
            return player.HandValue() > _dealer.HandValue() && !HasBusted(player) && !HasBusted(_dealer) ||
                   HasBusted(_dealer);
        }

        public bool HasPlayerWon(Player player)
        {
            return WinningPlayer.Contains(player);
        }
    }
}