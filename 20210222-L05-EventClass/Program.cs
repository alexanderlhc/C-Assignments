using System;
using System.Collections.Generic;

namespace _20210222_L05_EventClass
{
    class Program
    {
        static void Main(string[] args)
        {
          List<string> strings = new List<string>{"hello", "world!"};

          var stringToInt = EventClass.StringToInt;
          stringToInt = EventClass.CountChars;

          strings.ForEach(s => System.Console.WriteLine(stringToInt(s)));

          strings.ForEach(s => System.Console.WriteLine(EventClass.DelegateUser(s => s.Length, s)));
        }
    }

    class EventClass
    {
      public static Func<string, int> StringToInt;
      public delegate int StringTooInt(string input);

      public static int CountChars(string input) => input.Length;

      public static int DelegateUser(StringTooInt stt, string input) => stt(input);

    }
}
