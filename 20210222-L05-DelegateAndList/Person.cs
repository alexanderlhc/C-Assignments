using System;

namespace _20210222_L05_DelegateAndList
{
    class Person
    {
      public string Name { get; set; }
      public int Age { get; set; }
      public double Weight { get; set; }
      public int Score { get; set; }
      public bool Accepted { get; set; }

      public Person(string name, int age, double weight, int score)
      {
        Name = name;
        Age = age;
        Weight = weight;
        Score = score;
        Accepted = false;
      }

      public override string ToString()
      {
        return String.Format("{0,-10} | {1,-3} | {2,-3} | {3, -2} | {4}", Name, Age, Weight, Score, Accepted);
      }

    }
}
