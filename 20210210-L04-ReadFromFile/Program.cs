using System;
using System.Collections.Generic;

namespace _20210210_L04_ReadFromFile
{
    class Program
    {
        static void Main(string[] args)
        {
          string peopleCsv = "data.csv";
          List<Person> people = Person.ReadCSVFile(peopleCsv);
          System.Console.WriteLine("Number of people in data file : " + people.Count);

          /* people.Sort(new SortByAge()); */
          /* people.Sort(new SortByWeight()); */
          /* people.Sort(new SortByName()); */
          people.ForEach(p => System.Console.WriteLine(p));
        }


    }
}
