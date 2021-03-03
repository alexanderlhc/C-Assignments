using System;
using System.Collections.Generic;

namespace _20210222_L05_DelegateAndList
{
    class Program
    {
        static void Main(string[] args)
        {
          List<Person> people = GetPeople();


          Console.WriteLine(String.Format("{0,-10} | {1,-3} | {2,-3} | {3, -3} {4}", "Name", "Age", "Wei", "Sco", "Accepted"));
          Console.WriteLine("-----------|-----|-----|----|---------");

          // ===========
          // Exercise 1:

          // 1: People with score below 2
          /* List<Person> peopleScoreLessThan2 = people.FindAll(p => p.Score < 2); */
          /* peopleScoreLessThan2.ForEach(Console.WriteLine); */

          // 2: People with even score
          /* List<Person> peopleEvenScore = people.FindAll(p => p.Score % 2 == 0); */
          /* peopleEvenScore.ForEach(Console.WriteLine); */

          // 3: People with even score And WeighAbove60
          /* List<Person> peopleEvenScoreAndWeighAbove60 = peopleEvenScore.FindAll(p => p.Weight > 60); */
          /* peopleEvenScoreAndWeighAbove60.ForEach(Console.WriteLine); */


          // 4: People with weight divisible by 3
          /* List<Person> peopleWeightDivisibleBy3 = people.FindAll(p => p.Weight % 3 == 0); */
          /* peopleWeightDivisibleBy3.ForEach(Console.WriteLine); */


          // ===========
          // Exercise 2:

          // 1. Find first person with score == 3
          Person personWithScore3 = people.Find(p => p.Score == 3);
          /* System.Console.WriteLine(personWithScore3); */
          // 2. FindIndex to find the index of the first person under 10 years, with a score of 3.
          Predicate<Person> below10YearsAndScore3 = p => p.Age < 10 && p.Score == 3;
          int indexPersonBelow10YearsAndScore3 = people.FindIndex(below10YearsAndScore3);
          /* Console.WriteLine("Found index: " + indexPersonBelow10YearsAndScore3 + ". Printing person"); */
          /* Console.WriteLine(people[indexPersonBelow10YearsAndScore3]); */
          // 3. How many people are there under 10 years, with a score of 3?
          int countPplBelow10YearsAndScore3 = people.FindAll(below10YearsAndScore3).Count;
          /* Console.WriteLine("People below 10 years and with score 3 = " + countPplBelow10YearsAndScore3); */
          // 4. Use FindIndex to find the index of the first person under 8 years, with a score of 3.
          // 5. What does the return value mean. -1 means not found
          int indexPersonBelow8YearAndScore3 = people.FindIndex(p => p.Age < 8 && p.Score == 3);
          /* Console.WriteLine(indexPersonBelow8YearAndScore3); */


          // ===========
          // Exercise 3:

          // Sort persons after both Score and Age, (both ascending and descending)
          Comparison<Person> byScoreThenAge = (p1, p2) => {
            int ageComp = p1.Age.CompareTo(p2.Age);
            return (ageComp != 0) ? ageComp : p1.Score.CompareTo(p2.Score);
          };
          people.Sort(byScoreThenAge); // ascending
          people.Reverse(); // descending
          /* people.ForEach(Console.WriteLine); */

          // ===========
          // Exercise 4:
          // Write an extension method on the List<Person> class so you can make this call:
          /*
              List<Person> people = GetPeople();
              people.UpdatePeople(p => p.Score >= 6 && p.Age <= 40, (p) => { p.Accepted = true; });
          */
          /* List<Person> peopleEx4 = GetPeople(); */
          /* people.UpdatePeople(p => p.Score >= 6 && p.Age <= 40, (p) => { p.Accepted = true; }); */
          /* people.FindAll(p => p.Accepted).ForEach(Console.WriteLine); */
        }

        static List<Person> GetPeople()
        {
          string[] lines = System.IO.File.ReadAllLines("data1.csv");
          string[] personData;
          List<Person> people = new List<Person>();

          foreach (string line in lines)
          {
            personData = line.Split(";");
            people.Add(new Person(personData[0], int.Parse(personData[1]), double.Parse(personData[2]), int.Parse(personData[3])));
          }

          return people;
        }




    }

    public static class Extensions
    {
      /* people.UpdatePeople(p => p.Score >= 6 && p.Age <= 40, (p) => { p.Accepted = true; }); */
      /* Hint: Use a Predicate delegate and an Action delegate to solve this problem. */
      public static void UpdatePeople<T>(this List<T> list, Predicate<T> who, Action<T> what)
      {
        list.FindAll(who).ForEach(what);
      }
    }
}
