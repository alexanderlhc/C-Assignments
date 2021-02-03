using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20210203_L02_Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 6;

            // IF 

            // 1: Small
            if (a + b > 10)
                Console.WriteLine("The answer is greater than 10.");
            else
                Console.WriteLine("The answer is not greater than 10");

            // 2: Verbose
            if (a + b > 10)
            {
                Console.WriteLine("The answer is greater than 10");
            }
            else
            {
                Console.WriteLine("The answer is not greater than 10");
            }

            // 3: More conditions
            if ((a + b + c > 10) && (a == b))
            {
                Console.WriteLine("The answer is greater than 10");
                Console.WriteLine("And the first number is equal to the second");
            }
            else
            {
                Console.WriteLine("The answer is not greater than 10");
                Console.WriteLine("Or the first number is not equal to the second");
            }

            // Loops

            // 1: While
            int counter1= 0;
            while (counter1 < 10)
            {
                Console.WriteLine($"Hello World! The counter is {counter1}");
                counter1++;
            }

            // 2: do while
            int counter2 = 0;
            do
            {
                Console.WriteLine($"Hello World! The counter is {counter2}");
                counter2++;
            } while (counter2 < 10);

            // 3: For
            for (int counter3 = 0; counter3 < 10; counter3++)
            {
                Console.WriteLine($"Hello World! The counter is {counter3}");
            }



        }
    }
}
