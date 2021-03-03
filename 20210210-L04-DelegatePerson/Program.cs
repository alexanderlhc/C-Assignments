﻿using System;
using System.Collections.Generic;
/* using System.Linq; */
/* using System.Text; */
/* using System.Threading.Tasks; */

namespace _20210210_L04_DelegatePerson
{

  public class Person {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public delegate void CallDelegate(string firstName, string lastName); // void to test .Invoke
    public static CallDelegate callDelegate = (firstName, lastName) => System.Console.WriteLine($"{firstName} {lastName}");

    public void PrintFullNameLastNameFirst() {
      Console.WriteLine($"{LastName}, {FirstName}");
    }

    public void PrintFullNameAllCaps() {
      Console.WriteLine($"{LastName.ToUpper()}, {FirstName.ToUpper()}");
    }

    public void PrintFullNameLowerCase() {
      Console.WriteLine($"{LastName.ToLower()}, {FirstName.ToLower()}");
    }

    public void PrintShortName() {
      Console.WriteLine($"{FirstName.Substring(0, 1)}. {LastName}");
    }

    public void PrintName(string firstName, string lastName) { callDelegate.Invoke(firstName, lastName); }

    public static List<Person> CreateListOfPeople() {
      return new List<Person>()
      {
            new Person() { FirstName = "Stephen", LastName = "King" },
            new Person() { FirstName = "George", LastName = "Martin" },
            new Person() { FirstName = "Ernest", LastName = "Hemingway" },
            new Person() { FirstName = "William", LastName = "Shakespeare" }
      };
    }
  }

  public class PersonUserClass {

    public static void Main(string[] args) {
      var people = Person.CreateListOfPeople();

      ////////////////////////////////
      // Start here
      ////////////////////////////////
      // Hint:
      // This piece of code
      // foreach (var p in people)
      //   p.PrintFullNameLastNameFirst();
      // can be translated to
      // people.ForEach(p => p.PrintFullNameLastNameFirst());
      // using the ForEach method on List<>. ForEach takes a Lambda as input


      // ✅ Problem 1
      // Use this to simplify the foreach statements in the while loop below
      // so they take up only one line each, instead of two

      // ✅ Problem 2 (Answer in less than 30 seconds)
      // Did Problem 1 simplify or just make your code harder to read?

      // Problem 3 (May be a hard problem)
      // Give the PersonUserClass class a method PrintFullNameLastNameFirst (copy from Person class)
      // And add a delegate called Formatter to your Person class
      // and a method that takes a this type of delegate as input
      // so this call becomes possible on a person:
      //
      // p.CallDelegate((F, L) => PrintFullNameLastNameFirst(F, L))
      // Use this to translate all your ForEach lines in the while loop to something like
      // people.ForEach(p => p.CallDelegate((F, L) => PrintFullNameLastNameFirst(F, L)));
      //

      while (true) {
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("Hvordan vil du have udskrevet navnene?");
        Console.WriteLine("1: Efternavn efterfulgt af fornavn");
        Console.WriteLine("2: Efternavn efterfulgt af fornavn, store bogstaver");
        Console.WriteLine("3: Efternavn efterfulgt af fornavn, små bogstaver");
        Console.WriteLine("4: Kun forbogstav af fornavn efterfulgt af efternavn");
        Console.WriteLine();
        Console.WriteLine("q: For at afslutte!");
        Console.Write("> ");
        var input = Console.ReadLine();
        switch (input.ToUpper()) {
          case "1":
            Person.callDelegate = PrintFullNameLastNameFirst;
            break;
          case "2":
            Person.callDelegate = PrintFullNameAllCaps;
            break;
          case "3":
              Person.callDelegate = PrintFullNameLowerCase;
            break;
          case "4":
              Person.callDelegate = PrintShortName;
            break;
          case "Q": return;
          default:
              Console.WriteLine("Ukendt valg, prøv igen");
            break;
        }

        people.ForEach(p => p.PrintName(p.FirstName, p.LastName));
      }
    }

    public static void PrintFullNameLastNameFirst(string firstName, string lastName) {
      Console.WriteLine($"{lastName}, {firstName}");
    }

    public static void PrintFullNameAllCaps(string firstName, string lastName) {
      Console.WriteLine($"{lastName.ToUpper()}, {firstName.ToUpper()}");
    }

    public static void PrintFullNameLowerCase(string firstName, string lastName) {
      Console.WriteLine($"{lastName.ToLower()}, {firstName.ToLower()}");
    }

    public static void PrintShortName(string firstName, string lastName) {
      Console.WriteLine($"{firstName.Substring(0, 1)}. {lastName}");
    }



  }
}
