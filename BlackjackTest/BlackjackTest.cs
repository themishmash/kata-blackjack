using System;
using System.Collections.Generic;
using System.Linq;
using kata_blackjack;
using NUnit.Framework;

namespace blackjackTests
{
    public class Tests
    {
        private const string StayResponse = "0";
        private const string HitInput = "1";
        
        [SetUp]
        public void Setup()
        {
        }
        

        [Test]
         public void DealerWins()
         {
             var player = PlayerSpy.CreateLosingPlayer();
             var dealerDeck = new DeckMock(new[]
             {
                 new Card(CardFace.Eight, Suit.Hearts),
                 new Card(CardFace.Ten, Suit.Diamonds),
                 new Card(CardFace.Ace, Suit.Hearts), 
             });
             var dealer = new Soft17Player(dealerDeck);
             var blackjack = new BlackJack(new List<Player> {player}, dealer);
             blackjack.StartGame();
             
             Assert.AreEqual(true, blackjack.HasPlayerWon(dealer));
             Assert.AreEqual(GameStatus.Won, dealer.GameStatus); //not working
         }
         
         //Not using enum
         [Test]
         public void HumanWinsWithBlackJack()
         {
             var human = PlayerSpy.CreateBlackJackPlayer();
             var soft17Player = new Soft17Player(new Deck());
             var blackjack = new BlackJack(new List<Player> {human}, soft17Player);
             
             blackjack.StartGame(); 
             
             //Assert.AreEqual(true, blackjack.HasPlayerWon(human));
            Assert.AreEqual(GameStatus.BlackJack, human.GameStatus);
         }
         
         [Test]
         public void HumanWinsWithBlackJackEnum()
         {
             var dealerCards = new DeckMock(new[]
             {
                 new Card(CardFace.Eight, Suit.Hearts),
                 new Card(CardFace.Ten, Suit.Diamonds),
                
             });
             
             var playerCards = new DeckMock(new[]
             {
                 new Card(CardFace.Ace, Suit.Hearts), 
                 new Card(CardFace.Jack, Suit.Diamonds), 
             });
             var playerResponse = new TestResponder(new []
             {
                 StayResponse,
             });
             var player = new Human(playerCards, playerResponse);
             var soft17Player = new Soft17Player(dealerCards);
             var blackjack = new BlackJack(new List<Player> {player}, soft17Player);
             
             blackjack.StartGame();
             
             Assert.AreEqual(GameStatus.BlackJack, player.GameStatus);
         }
         
         [Test]
         public void DealerBusts()
         {
             var player = PlayerSpy.CreatePlayerHandValue18();
             var dealerDeck = new DeckMock(new[]
             {
                 new Card(CardFace.Jack, Suit.Hearts),
                 new Card(CardFace.Six, Suit.Spades),
                 new Card(CardFace.Nine, Suit.Diamonds),
             });
           
             var dealer = new Soft17Player(dealerDeck);
             var blackjack = new BlackJack(new List<Player> {player}, dealer);
            
             blackjack.StartGame();
            
             //Assert.AreEqual(true, blackjack.HasBusted(dealer));
             Assert.AreEqual(GameStatus.Busted, dealer.GameStatus);
         } 

        [Test]
        public void HumanHitsAndBusts()
        {
            var player = PlayerSpy.CreateBustedPlayer();
            var dealerDeck = new DeckMock(new[]
            {
                new Card(CardFace.Jack, Suit.Hearts),
                new Card(CardFace.Eight, Suit.Spades),
            });
            
            var dealer = new Soft17Player(dealerDeck);
            var blackjack = new BlackJack(new List<Player>{player}, dealer);

            blackjack.StartGame();
            
           // Assert.AreEqual(true, blackjack.HasBusted(player));
            Assert.AreEqual(GameStatus.Busted, player.GameStatus);
        }
        
        
        [Test]
        public void EachPlayerPlaysTheirTurn()
        {
            var deck = new Deck();

            var player1 = new PlayerSpy(deck, 0);
            var player2 = new PlayerSpy(deck, 1);
            
            var dealer = new Soft17Player(deck);
            var blackjack = new BlackJack(new []{player1, player2}, dealer);
            
            blackjack.StartGame();
            
            Assert.NotZero(player1.NumberOfTimesTurnPlayed);
            Assert.NotZero(player2.NumberOfTimesTurnPlayed);
            
        }


        [Test]
        public void NumberOfTimesPlayTurnCalledForPlayer()
        {
            var deck = new Deck();
            var playerResponses = new TestResponder(new [] { HitInput, StayResponse });
            var player = new PlayerSpy(deck, 1);
            var dealer = new Soft17Player(deck);
            var blackjack = new BlackJack(new []{player}, dealer);
            blackjack.StartGame();
            
            Assert.AreEqual(1, player.NumberOfTimesTurnPlayed);
            
        }
        
        

        [Test]
        public void DealerPlaysTurnAfterAllPlayersPlayTurn()
        {
            var deck = new Deck();
            var deckStartCount = deck.CardsLeft();
            
            var players = new List<Player>()
            {
                new Soft17Player(deck),
                new Soft17Player(deck),
                new Soft17Player(deck),
            };
           
            var dealer = new DealerSpy(deck);
            var blackjack = new BlackJack(players, dealer);
            
            blackjack.StartGame();

            var cardsLeftBeforeDealersTurn = dealer.CardsLeftInDeckBeforeTurn;
            var cardsIfNoPlayerPlayed = deckStartCount - players.Count * 2 - 2;

            Assert.AreNotEqual(cardsIfNoPlayerPlayed,cardsLeftBeforeDealersTurn);
            
        }
        
        //TODO 1. create always hit player in test 2. create 5 players to account for 4 players miraculously getting blackjack. so dealer and 3 players 3. 
        [Test]
        public void DealerPlaysTurnAfter3PlayersPlayTurn()
        {
            var deck = new Deck();
            var deckStartCount = deck.CardsLeft();
            
            var players = new List<Player>()
            {
                new PlayerAlwaysHits(deck),
                new PlayerAlwaysHits(deck),
                new PlayerAlwaysHits(deck),
                new PlayerAlwaysHits(deck)
            };
           
            var dealer = new DealerSpy(deck);
            var blackjack = new BlackJack(players, dealer);
            
            blackjack.StartGame();
        
            var cardsLeftBeforeDealersTurn = dealer.CardsLeftInDeckBeforeTurn;
            var cardsIfNoPlayerPlayed = deckStartCount - players.Count * 2 - 2;

            Assert.AreNotEqual(cardsIfNoPlayerPlayed,cardsLeftBeforeDealersTurn);
            Assert.AreEqual(42, cardsIfNoPlayerPlayed);
        }
        

    }
}