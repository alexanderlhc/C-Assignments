
using System;

namespace _20210203_L02_PersonAge
{
    class Person
    {

      public static int calcAge(in int birthYear, out int age)
        {
            return age = DateTime.Now.Year - birthYear;
      }

    }
}
