using System;

namespace _20210208_L03_Generic
{
    class Program
    {
        static void Main(string[] args)
        {
           BoguCollection bogu = new BoguCollection();

           for (int i = 0; i < 5; i++)
           {
             System.Console.WriteLine("Adding ({0},{0}) = {1}", i, bogu.AddElement(i,i));
           }

            System.Console.WriteLine(bogu.Size());

            System.Console.WriteLine(bogu.GetElement(1));
        }
    }
}
