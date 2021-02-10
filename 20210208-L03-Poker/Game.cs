using System;
using System.Collections.Generic;

namespace _20210208_L03_Poker
{
  class Game
  {
    public static int gameIDLast = 0;
    public int gameID;

    public Game()
    {
      Game.gameIDLast++;
      gameID = gameIDLast;
    }

    public List<Card> GetNewDeck()
    {
      List<Card> deck = new List<Card>();

      foreach (SUIT suit in Enum.GetValues(typeof(SUIT)))
      {
          foreach (VALUE value in Enum.GetValues(typeof(VALUE)))
          {
            deck.Add(new Card(suit, value));
          }
      }

      return deck;
    }

  }

}
