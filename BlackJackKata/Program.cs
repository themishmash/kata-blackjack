namespace kata_blackjack
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var deck = new Deck();
            var dealer = new Dealer(deck);
            var human = new Human(deck, new ConsoleInputOutput());
            var blackjack = new BlackJack(dealer, human);
            
            blackjack.StartGame();
          
            
       
        }

    
     
    }
}