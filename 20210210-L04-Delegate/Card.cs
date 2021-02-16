
namespace _20210210_L05_Delegate
{
  enum SUIT {
    DIAMOND,
    CLUB,
    SPADE,
    HEART
  }

  enum VALUE {
    TWO=2,
    THREE=3,
    FOUR=4,
    FIVE=5,
    SIX=6,
    SEVEN=7,
    EIGHT=8,
    NINE=9,
    TEN=10,
    J=11,
    Q=12,
    K=13,
    A=14,
  }

  class Card
  {
    public SUIT Suit { get; }
    public VALUE Value { get; }

    public Card(SUIT suit, VALUE value)
    {
      Suit = suit;
      Value = value;
    }


    public override string ToString()
    {
      return string.Format("[{0} of {1}]", Value, Suit);
    }
  }
}

