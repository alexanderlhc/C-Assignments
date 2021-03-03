using System;
using System.Collections.Generic;
using System.Linq;

namespace _20210222_LINQ
{
  public class Program
  {
    static void Main(string[] args)
    {
      List<Person> people = GetPeopleFromCSV("data.csv");


      // Ex 8 + 9
      /* SortPeopleByScoreAndAge(people); */
      /* SortPeopleByDistanceFromAvgAge(people); */
      /* SortPeopleByDWA(people); */

      // Ex 11
      /* people.Take(5).ToList().ForEach(System.Console.WriteLine); */
      /* people.Reset(); */
      /* System.Console.WriteLine("people.Reset()"); */
      /* people.Take(5).ToList().ForEach(System.Console.WriteLine); */

      // Ex 13
      /* GroupPeopleByFirstLetter(people); */
      // Ex 14
      List<Person> people2 = GetPeopleFromCSV("data2.csv");
      var peopleIntersect =
        (from p in people select p.Name)
        .Intersect(from p in people2 select p.Name);

      foreach (String name in peopleIntersect)
        System.Console.WriteLine(name);


      // Ex 10
      int[] numbers = { 34, 8, 56, 31, 79, 150, 88, 7, 200, 47, 88, 20 };
      /* PrintTwoDigitSorted(numbers, true); */
      /* PrintTwoDigitSorted(numbers, false); */
      /* PrintTwoDigitAsString(numbers, false); */
      /* PrintTwoDigitAsString(numbers, true); */

      // Ex 12
      /* Random rng = new Random(); */
      /* int[] rngNumbers = new int[10]; */
      /* for (int i = 0; i < rngNumbers.Count(); i++) */
      /*     rngNumbers[i] = rng.Next(1, 10); */

      /* System.Console.Write($"Numbers: {String.Join(", ", rngNumbers.Select(i => i.ToString()).ToArray())}"); */

      /* int oddNumbers = (from num in rngNumbers where (num % 2 == 1) select num).Count(); */
      /* int distinctNumbers = (from num in rngNumbers.Distinct() select num).Count(); */
      /* int[] first3OddNumbers = (from num in rngNumbers where (num % 2 == 1) select num).Take(3).ToArray(); */
      /* int[] oddDistinctNumbers = (from num in rngNumbers.Distinct() where (num % 2 == 1) select num).ToArray(); */
      /* System.Console.WriteLine($"\noddNumbers {oddNumbers}. Distinct {distinctNumbers}. 3 first odd: {first3OddNumbers[0]} {first3OddNumbers[1]} {first3OddNumbers[2]}."); */
      /* System.Console.Write($"Distinct odd numbers: {String.Join(", ", oddDistinctNumbers.Select(i => i.ToString()).ToArray())} \n"); */
    }

    private static void GroupPeopleByFirstLetter(List<Person> people)
    {
      var peopleGroup =
        from p in people
        let fLetter = p.Name[0]
        group p by fLetter into firstLetter
        orderby firstLetter.Key
        select firstLetter;

      foreach(var letter in peopleGroup)
      {
        System.Console.WriteLine(letter.Key);
        foreach(var p in letter.Take(2))
          System.Console.WriteLine(p);
      }
    }

  public static List<Person> GetPeopleFromCSV(string file)
    {
      string[] lines = System.IO.File.ReadAllLines(file);
      string[] personData;
      List<Person> people = new List<Person>{};

      foreach (string line in lines)
      {
        personData = line.Split(";");
        people.Add(new Person(personData[0], int.Parse(personData[1]), int.Parse(personData[2])));
      }

      return people;
    }

    private static void PrintTwoDigitSorted(int[] numbersIn, bool isAscending)
    {
      var numbers =
        from num in numbersIn
        where num > 10
        orderby (isAscending) ? num : num * -1
        select num;

      numbers.ToList().ForEach(num => System.Console.Write($"{num}, "));
      System.Console.WriteLine();
    }

    private static void PrintTwoDigitAsString(int[] numbersIn, bool withEven)
    {
      var numbers =
        from num in numbersIn
        where num > 10
        let number =  num.ToString() + ((withEven) ? (num % 2 == 0) ? " even" : " uneven" : "")
        select number;

      numbers.ToList().ForEach(num => System.Console.Write($"{num} {num.GetType()}, "));
      System.Console.WriteLine();
    }


    public static void SortPeopleByScoreAndAge(List<Person> peopleIn)
    {
      IEnumerable<Person> pplByScoreAndAge =
        from p in peopleIn
        orderby p.Score, p.Age
        // orderby p.Score descending, p.Age descending
        select p;

      foreach(Person p in pplByScoreAndAge.Take(5).ToList()) Console.WriteLine(p);
    }

    public static void SortPeopleByDistanceFromAvgAge(List<Person> peopleIn)
    {

      var peopleSorted =
        from p in peopleIn
        let average = (from pA in peopleIn select pA.Age).Average()
        orderby Math.Abs((average - p.Age))
        select p;

      List<Person> people = new List<Person>(peopleSorted.Take(15).ToList());

      people.ForEach(System.Console.WriteLine);
    }

    public static void SortPeopleByDWA(List<Person> peopleIn)
    {
      var peopleSorted =
        from p in peopleIn
        let dwa = Math.Sqrt(Math.Pow(p.Score, 2)+Math.Pow(p.Age, 2))
        orderby dwa
        select new { p, dwa };

      peopleSorted.Take(15).ToList().ForEach(System.Console.WriteLine);
    }

  }

  public class Person
  {
    public string Name {get; set; }
    public int Age {get; set; }
    public int Score {get; set; }
    public bool Accepted { get; set; }

    public Person(string name, int age, int score)
    {
      Name = name;
      Age = age;
      Score = score;
      Accepted = Score > 50;
    }

    public override string ToString() => String.Format($"({Name} {Age} {Score} {Accepted})");

  }

  public static class Extensions
  {
    public static void Reset(this List<Person> people) => people.FindAll(p => p.Accepted).ForEach(p => p.Accepted = false);
  }

}
