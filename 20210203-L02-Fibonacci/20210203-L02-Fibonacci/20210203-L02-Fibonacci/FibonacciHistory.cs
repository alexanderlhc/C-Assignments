using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _20210203_L02_Fibonacci
{
    class FibonacciHistory
    {
        private Dictionary<int, long> cache = new Dictionary<int, long>();

        public long fib(int n)
        {
            long result;

            if (n == 0 || n == 1)
                return n;

            if (cache.ContainsKey(n))
                result = cache[n];
            else
            {
                result = fib(n - 1) + fib(n - 2);
                cache.Add(n, result);
            }

            return result;
        }

        public (long, long) fibWithTime(int n)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            long result = fib(n);
            stopwatch.Stop();

            return (result, stopwatch.ElapsedMilliseconds);
        }
    }
}
