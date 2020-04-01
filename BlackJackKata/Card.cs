using System;
using System.Collections.Generic;

namespace blackjack
{
    public class Card
    {
      

      public enum Suits
      {
          Clubs,
          Diamonds,
          Hearts,
          Spades
      }
      //value numerical
      public int Value;
      public Suits Suit;
      
      public string NamedValue
      {
          get
          {
              string [] valueString = {string.Empty};
              
              //string suitSentence = string.Empty;
              switch (Value)
              {
                  case 10:
                      valueString = new []{"Jack", "Queen", "King"};
                      break;
                  default:
                      valueString = new [] {Value.ToString()};
                      break;
              }

              return valueString.ToString();
          }
      }

      public string Name
      {
          get
          {
              return NamedValue + " of " + Suit.ToString();
          }
      }

      public Card(int value, Suits suit)
      {
          Value = value;
          Suit = suit;

      }

      

      

      // public Card(string input)
      // {
      //     string [] valueString = {string.Empty};
      //     
      //     string suitSentence = string.Empty;
      //
      //     switch (Value)
      //     {
      //         case 10:
      //             valueString = new []{"Jack", "Queen", "King"};
      //             break;
      //         default:
      //             valueString = new [] {Value.ToString()};
      //             break;
      //     }
      //
      //     switch (Suit)
      //     {
      //         case Suits.Clubs:
      //             suitSentence = " of Clubs";
      //             break;
      //         case Suits.Diamonds:
      //             suitSentence = " of Diamonds";
      //             break;
      //         case Suits.Hearts:
      //             suitSentence = " of Hearts";
      //             break;
      //         case Suits.Spades:
      //             suitSentence = " of Spades";
      //             break;
      //     }
      //
      //     input = valueString + suitSentence;
      // }
      
      //constructor to create individual card with 
    }
}