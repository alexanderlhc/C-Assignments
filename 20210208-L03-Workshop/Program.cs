using System;
using System.Collections.Generic;

namespace Ex3
{
    class Program
    {
        static void Main(string[] args)
        {
          Person p1 = new Person("Karen Kunde", "Rabalderstrædet");
          Mechanic m1 = new Mechanic("Maks Mekanik", "Prolitariatsvej", 1970, 250);
          Foreman f1 = new Foreman("Carl Smart", "Strandvejen", 2010, 450, 2011, 20000);
          Inspector i1 = new Inspector("Åge Lund", "Sødalen", 1800, 350);
          List<Person> people = new List<Person>{p1, m1, f1, i1};

          foreach (Person p in people)
          {
              System.Console.WriteLine();
              System.Console.WriteLine(p);
              if (p is Mechanic)
                System.Console.WriteLine("Wage: {0}", (p as Mechanic).getSalary());
          }
        }
    }
}
