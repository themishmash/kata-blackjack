
namespace kata_blackjack
{
    public class Dealer : Player
    {
        // public readonly List<Card> Hand = new List<Card>();
        //private readonly IDeck _deck;
        
        public Dealer(IDeck deck) : base(deck)
        {
            //_deck = deck;
        }
        // public readonly List<Card> DealerList = new List<Card>();
        //
        //
        //
        //
        // public Dealer()
        // {
        //     
        // }
        //
        // public int CardTotalValue()
        // {
        //     return DealerList.Sum(card => card.Value);
        // }
        //
        //
        //
        // public void AddOneCardToDealerHand(Deck deck)
        // {
        //     var dealerCard = deck.DrawOneCardFromDeck();
        //     DealerList.Add(dealerCard);
        //     
        // }
        //
        // public int NumberOfDealerCards()
        // {
        //     return DealerList.Count;
        // }
        //
        // public void PrintDealerHand()
        // {
        //     foreach (Card card in DealerList)
        //     {
        //         Console.WriteLine($"{card.CardFace} of {card.Suit}");
        //     }
        // }
    }
}