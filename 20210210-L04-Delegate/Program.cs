using System;

namespace _20210210_L05_Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
          // Exercise 4
          /* Numbers numbers = new Numbers(); */

          // Initate in order
          Deck deck = new Deck();
          System.Console.WriteLine("Unsorted: ");
          deck.ForEach(c => Console.Write(c + ","));

          // Shuffle
          System.Console.WriteLine("\n\nShuffled: ");
          deck.SortDeck(Deck.sortShuffle);
          deck.ForEach(c => Console.Write(c + ","));

          // Value then color lambda
          System.Console.WriteLine("\n\nVal then color: ");
          deck.SortDeck((c1, c2) => {
              int valComp = c1.Value.CompareTo(c2.Value);
              return (valComp == 0) ? c1.Suit.CompareTo(c2.Suit) : valComp;
          });
          deck.ForEach(c => Console.Write(c + ","));

          // Default
          System.Console.WriteLine("\n\n Default Color then Val: ");
          deck.SortDeck(Deck.sortBySuitThenValue);
          deck.ForEach(c => Console.Write(c + ","));
        }
    }
}
