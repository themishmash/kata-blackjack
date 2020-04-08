


namespace kata_blackjack
{
    public class Human : Player
    
    {
        //public readonly List<Card> Hand = new List<Card>();
        //private readonly IDeck _deck;
        
        public Human(IDeck deck) : base(deck)
        {
            //_deck = deck;
        }
        
        // public void AddOneCardToHand()
        // {
        //     var humanCard = _deck.DrawOneCardFromDeck();
        //     Hand.Add(humanCard);
        //     
        // }

        // public int NumberOfHumanCards()
        // {
        //     return Hand.Count;
        // }
        
        // public int CardTotalValue()
        // {
        //     return Hand.Sum(card => card.Value);
        // }
        //
        // public void PrintHumanHand()
        // {
        //     foreach (Card card in Hand)
        //     {
        //         Console.WriteLine($"{card.CardFace} of {card.Suit}");
        //     }
        // }

    }
}