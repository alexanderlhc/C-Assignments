using System;

namespace _20210208_L03_Property
{
    class Program
    {
        static void Main(string[] args)
        {
          var mc = new MyClass(56);
          System.Console.WriteLine(mc);
          mc.Arg = 65;
          System.Console.WriteLine(mc);
        }
    }

    class MyClass
    {
      public int Arg { get; set; }

      public MyClass(int number)
      {
        Arg = number;
      }

      public override string ToString()
      {
        return String.Format("MyArg set to {0}",Arg);
      }
    }
}
