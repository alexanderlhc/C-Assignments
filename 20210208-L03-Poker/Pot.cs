using System;

namespace _20210208_L03_Poker
{
  class Pot
  {
    public int Money {
      get;
      private set;
    }

    private Player owner;


    public Pot(Player player)
    {
      owner = player;
    }

    public void AddMoney(int money)
    {
      Money += money;
    }
  }
}
