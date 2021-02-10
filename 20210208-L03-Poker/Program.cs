using System;

namespace _20210208_L03_Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            foreach (Card card in game.GetNewDeck())
            {
              System.Console.WriteLine(card);
            }
        }
    }
}
