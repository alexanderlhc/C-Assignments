using System;
using System.Collections.Generic;
namespace _20210208_L03_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
          List<Person> people = new List<Person>() {
            new Person("Bbb", 20),
            new Person("Aaa", 10),
            new Person("Ccc", 30),
            new Person("Eee", 50),
            new Person("Ddd", 40),
          };

          System.Console.WriteLine("Unsorted (initial): ");
          people.ForEach(p => Console.Write(p + "; "));
          System.Console.WriteLine();
          /* System.Console.WriteLine("Sort by age p1.Age.CompareTo(p2.Age): "); */
          /* people.Sort((p1, p2) => p1.Age.CompareTo(p2.Age)); */
          /* System.Console.WriteLine(); */

          System.Console.WriteLine("Sort by Person.CompareByAge: ");
          people.Sort(Person.CompareByAge);
          people.ForEach(p => Console.Write(p + "; "));
          System.Console.WriteLine();
        }
    }
}
