using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20210203_L02_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            FibonacciHistory fibHistory = new FibonacciHistory();
            (long, long) resHis; // result from FibonacciHistory.cs
            (long, long) resSim; // result from Fibonacci.cs

            for (int i = 30; i < 40; i++)
            {
                Console.WriteLine("==== Calculating fib({i})");
                resSim = Fibonacci.fibWithTime(i);
                resHis = fibHistory.fibWithTime(i);

                Console.WriteLine("Simple: Duration {0}ms. Result = {1}", resSim.Item2, resSim.Item1);
                Console.WriteLine("Cached: Duration {0}ms. Result = {1}", resHis.Item2, resHis.Item1);
                Console.WriteLine("\n\n");
            }

            Console.ReadKey();
        }
    }
}
