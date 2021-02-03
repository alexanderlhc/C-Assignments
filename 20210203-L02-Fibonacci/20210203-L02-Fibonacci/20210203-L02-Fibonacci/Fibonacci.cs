using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20210203_L02_Fibonacci
{
    class Fibonacci
    {
        public static long fib(int n)
        {
            if (n == 0 || n == 1)
                return n;

            return fib(n - 1) + fib(n - 2);
        }

        public static (long, long) fibWithTime(int n)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            long result = fib(n);
            stopwatch.Stop();

            return (result, stopwatch.ElapsedMilliseconds);
        }

    }
}
