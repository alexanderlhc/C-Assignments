using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFindMax
{
    class Program
    {
        static void Main(string[] args)
        {
            double m1 = Max(28.5, 17.2);
            double m2 = Max(4.0, 10.8, 34.25, 2.0, 23.6);
            Console.WriteLine("Max: ");
            Console.WriteLine(m1 + " " + m2);

            // Max While Loop Test
            double mw1 = MaxWhile(28.5, 17.2);
            double mw2 = MaxWhile(4.0, 10.8, 34.25, 2.0, 23.6);
            Console.WriteLine("Max with While: ");
            Console.WriteLine(mw1 + " " + mw2);


            Console.ReadLine();
        }

        public static double Max(params double[] numbers)
        {
            double highestNumber = numbers[0];

            foreach (double number in numbers)
            {
                if(number > highestNumber)
                {
                    highestNumber = number;
                }
            }

            return highestNumber;
        }
        public static double MaxWhile(params double[] numbers)
        {
            int numbersCount = numbers.Length;
            double number = numbers[0];
            double highestNumber = number;
            int index = 1;

            while (index < numbersCount)
            {
                number = numbers[index];
                if (number > highestNumber)
                {
                    highestNumber = number;
                }
                index++;
            }

            return highestNumber;
        }

    }

}
