using System;
using System.Collections.Generic;

namespace _20210210_L05_Delegate
{
  class Deck : List<Card>
  {

    public delegate int SortOrder(Card c1, Card c2);


    public Deck()
    {
      MakeDeck();
    }

    public static int sortBySuitThenValue(Card c1, Card c2)
    {
      int suitComp = c1.Suit.CompareTo(c2.Suit);
      return (suitComp == 0) ? c1.Value.CompareTo(c2.Value) : suitComp;
    }

    public static int sortShuffle(Card c1, Card c2)
    {
      return new Random().Next(-1, 1);
    }

    private void MakeDeck()
    {
      foreach (SUIT suit in Enum.GetValues(typeof(SUIT)))
      {
        foreach (VALUE value in Enum.GetValues(typeof(VALUE)))
        {
          this.Add(new Card(suit, value));
        }
      }
    }

    /* Can't overwrite Collections.Sort */
    public void SortDeck()
    {
      SortDeck(sortShuffle);
    }

    public void SortDeck(SortOrder sortOrder)
    {
      /* this.Sort(sortOrder); */
      this.Sort((c1, c2) => sortOrder(c1, c2));
    }

  }
}
