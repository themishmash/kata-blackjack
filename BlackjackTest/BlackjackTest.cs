using System.Collections.Generic;
using kata_blackjack;
using NUnit.Framework;

namespace blackjackTests
{
    public class Tests
    {
        private const string StayResponse = "0";
        private const int NoHits = 0;
        private const int OneHit = 1;
        private const int CardsDealtToPlayer = 2;
        private const int CardsDealtToDealer = 2;
        
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
             var console = new ConsoleInputOutput();
             var blackjack = new BlackJack(new List<Player> {player}, console, dealer);
             blackjack.StartGame();
             
             Assert.AreEqual(GameStatus.Won, dealer.GameStatus); 
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
             var console = new ConsoleInputOutput();
             var blackjack = new BlackJack(new List<Player> {player}, console, soft17Player);
             
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
             var console = new ConsoleInputOutput();
             var blackjack = new BlackJack(new List<Player> {player}, console, dealer);
            
             blackjack.StartGame();
             
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
            var console = new ConsoleInputOutput();
            var blackjack = new BlackJack(new List<Player>{player}, console, dealer);

            blackjack.StartGame();
            
            Assert.AreEqual(GameStatus.Busted, player.GameStatus);
        }
        
        [Test]
        public void EachPlayerPlaysTheirTurn()
        {
            var deck = new Deck();

            var player1 = new PlayerSpy(deck, NoHits);
            var player2 = new PlayerSpy(deck, OneHit);
            
            var dealer = new Soft17Player(deck);
            var console = new ConsoleInputOutput();
            var blackjack = new BlackJack(new Player[]{player1, player2}, console, dealer);
            
            blackjack.StartGame();
            
            Assert.NotZero(player1.NumberOfTimesTurnPlayed);
            Assert.NotZero(player2.NumberOfTimesTurnPlayed);
        }

        [Test]
        public void NumberOfTimesPlayTurnCalledForPlayer()
        {
            var deck = new Deck();
            var player = new PlayerSpy(deck, OneHit);
            var dealer = new Soft17Player(deck);
            var console = new ConsoleInputOutput();
            var blackjack = new BlackJack(new Player[]{player}, console, dealer);
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
            var console = new ConsoleInputOutput();
            var blackjack = new BlackJack(players, console, dealer);
            
            blackjack.StartGame();

            var cardsLeftBeforeDealersTurn = dealer.CardsLeftInDeckBeforeTurn;
            var cardsIfNoPlayerPlayed = deckStartCount - players.Count * CardsDealtToPlayer - CardsDealtToDealer;

            Assert.AreNotEqual(cardsIfNoPlayerPlayed,cardsLeftBeforeDealersTurn);
        }
        
        [Test]
        public void DealerPlaysTurnAfter4PlayersPlayTurn()
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
            var console = new ConsoleInputOutput();
            var blackjack = new BlackJack(players, console, dealer);
            
            blackjack.StartGame();
        
            var cardsLeftBeforeDealersTurn = dealer.CardsLeftInDeckBeforeTurn;
            var cardsIfNoPlayerPlayed = deckStartCount - players.Count * CardsDealtToPlayer - CardsDealtToDealer;

            Assert.AreNotEqual(cardsIfNoPlayerPlayed,cardsLeftBeforeDealersTurn);
        }
    }
}