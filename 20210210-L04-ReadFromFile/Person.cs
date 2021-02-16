using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace _20210210_L04_ReadFromFile
{
  public class Person
  {
    public string Name { get; }
    public int Age { get; }
    public double Weight { get; }

    public Person(string input)
    {
      string[] data = input.Split(';');
      Name = data[0];
      Age = int.Parse(data[1]);
      Weight = double.Parse(data[2]);
    }

    public override string ToString()
    {
      return string.Format("{0} is {1} years old, and weighs {2}", Name, Age, Weight);
    }

    public static List<Person> ReadCSVFile(string filename)
    {
      string[] lines = System.IO.File.ReadAllLines(filename);
      List<Person> people = new List<Person>();

      foreach (string personData in lines)
      {
        people.Add(new Person(personData));
      }

      return people;
    }
  }

  public class SortByAge : IComparer<Person>
  {
    public int Compare(Person p1, Person p2)
    {
      return p1.Age.CompareTo(p2.Age);
    }
  }
  public class SortByWeight : IComparer<Person>
  {
    public int Compare(Person p1, Person p2)
    {
      return p1.Weight.CompareTo(p2.Weight);
    }
  }
  public class SortByName : IComparer<Person>
  {
    public int Compare(Person p1, Person p2)
    {
      return p1.Name.CompareTo(p2.Name);
    }
  }
}
