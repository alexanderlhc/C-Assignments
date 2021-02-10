using System;

namespace _20210208_L03_PrintFormat
{
    class Person
    {
      public string Name { get; set; }
      public int Age { get; set; }
      public double Weight { get; set; }

      public Person(string name, int age, double weight)
      {
        Name = name;
        Age = age;
        Weight = weight;
      }

      public Person(string personData)
      {
        string[] data = personData.Split(';');
        /* if (data.Length != 3) throw new ArgumentException("Input invalid"); */
        // should also check if type casting should throw
        // TODO: call to base?
        Name = data[0];
        Age = int.Parse(data[1]);
        Weight = double.Parse(data[2]);
      }

      public override string ToString()
      {
        return string.Format("{0, -10} is {1, -3} and weighs {2, 3}kg", Name, Age, Weight);
      }
    }
}
