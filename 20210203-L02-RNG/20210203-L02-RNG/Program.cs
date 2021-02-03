using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20210203_L02_RNG
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            int chambers = 6;
            double cash = 100;
            double rate = 1.25;
            bool isDead = false;
            ConsoleKeyInfo keypress = default;

            Console.WriteLine("Ready to start with {0}$? (y/N)", cash);
            keypress = Console.ReadKey();

            while(keypress.KeyChar != 'n' && !isDead)
            {
                if(rng.Next(1,chambers) == 1)
                {
                    Console.WriteLine("*BAM* you're out!");
                    isDead = true;
                }
                else
                {
                    Console.WriteLine("*HOLLOW CLUNK*... lucky you!");
                    cash *= rate;
                    Console.WriteLine("You have {0}$ in cash!", cash);
                    Console.WriteLine("Wanna try again? (y/N)");
                    keypress = Console.ReadKey();
                    Console.WriteLine();
                }

            }

            if (isDead)
                Console.WriteLine("Game ended, you would've earned {0}$", cash);
            else
                Console.WriteLine("Other than winning the life lottery, you earned {0}$", cash);


            Console.ReadKey();
        }
    }
}
