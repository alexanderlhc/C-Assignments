using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200203_L02_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // integers
            // Supports: +, -, *, / ...
            int a = 1;
            int b = 2;
            int c = a + b; // = 3
            Console.WriteLine("{0} + {1} = {2}", a, b, c);

            // Order of operations
            int d = a + b * c;          // = 7
            int e = (a + b) * c;        // = 9
            Console.WriteLine("{0} + {1} * {2} = {3}", a, b, c, d);
            Console.WriteLine("({0} + {1}) * {2} = {3}", a, b, c, e);


            // Precision and limits
            int f = (a + b) / c;       // = 7
            int g = (a + b) % c;       // = 9
            Console.WriteLine($"quotient: {d}");
            Console.WriteLine($"remainder: {e}");


            // Limits
            int max = int.MaxValue;
            int min = int.MinValue;
            Console.WriteLine($"The range of integers is {min} to {max}");
            int what = max + 3; // = -2147483646
            Console.WriteLine($"An example of overflow: {what}");

            ///// Doubles
            double dmax = double.MaxValue;
            double dmin = double.MinValue;
            Console.WriteLine($"The range of double is {dmin} to {dmax}");

            // Decimal
            decimal h = 1.0M;
            decimal i = 2.0M;
            Console.WriteLine(a / b);
            Console.WriteLine(h / i);

            Console.ReadKey();
        }
    }
}
