using System;

namespace _20210208_L03_Poker
{
    class Player
    {
      public int Money { get; set; }
      public string Name { get; }

      public Player(string name):this(name, 0) { }

      public Player(string name, int money)
      {
        Name = name;
        Money = money;
      }
    }
}
