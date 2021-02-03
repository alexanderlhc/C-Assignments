using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20210203_L02_PersonAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] birthYears = { 0, 3000, 2002, 2010 };
            int age1, age2;

            foreach(int birthYear in birthYears)
            {
                age2 = 0;
                age1 = Person.calcAge(birthYear, out age1);
                Person.calcAge(birthYear, out age2);

                Console.WriteLine("Birthyear = {0}.\n - ret {1}\n - out {2}\n", birthYear, age1, age2);
            }

            Console.ReadLine();
        }
    }
}
