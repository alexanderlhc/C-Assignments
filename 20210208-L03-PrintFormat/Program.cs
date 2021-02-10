using System;
using System.Collections.Generic;

namespace _20210208_L03_PrintFormat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>() { new Person("Aksel", 50, 60), new Person("Benny", 40, 80) };

            foreach (Person person in people)
            {
                System.Console.WriteLine(person);
            }

            System.Console.Write("Input: ");
            System.Console.WriteLine(new Person(Console.ReadLine()));

            //System.Console.WriteLine(new Person(input));
        }
    }
}
