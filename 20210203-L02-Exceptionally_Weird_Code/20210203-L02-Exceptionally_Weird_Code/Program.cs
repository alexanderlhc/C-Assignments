using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20210203_L02_Exceptionally_Weird_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many exceptions can you catch?:");
            try
            {
                int num = Convert.ToInt32(Console.ReadLine());
                MyMethodWithError(num);
            }
            catch (Exception e)
            {
                Console.WriteLine("Congratulations you caught:\n{0}", e);
            }
            finally
            {
                Console.WriteLine("Aaaand done");
            }

            Console.ReadKey();
        }

        private static void MyMethodWithError(int num = 0)
        {
            if (num % 2 == 0)
                throw new RegretableActionException("WHAT ARE YOU DOING?");
            else
                Console.WriteLine("Not this time!");
        }


    }
}
