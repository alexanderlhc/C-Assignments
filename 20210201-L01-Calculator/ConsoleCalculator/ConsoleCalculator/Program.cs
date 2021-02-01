using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)        {
            double num1;
            double num2;
            char symbol;
            double result;

            Console.WriteLine("Calculator\n");

            num1 = getNumber();
            symbol = getSymbol();
            num2 = getNumber();
            result = calculation(num1, symbol, num2);
            Console.WriteLine("{0} {1} {2} = {3}", num1, symbol, num2, result);

            Console.ReadKey();
        }

        private static double getNumber()
        {
            double? num = null;

            Console.Write("Write a number: ");
            while (num == null)
            {
                try
                {
                    num = Convert.ToDouble(Console.ReadLine());
                } 
                catch (FormatException e)
                {
                    Console.WriteLine("{0}\nInvalid number, try again!:",e);
                }
            }

            Console.WriteLine();
            return (double)num;
        }
        private static char getSymbol()
        {
            string symbolsValid = "+-*/";
            char? symbol = null;
            string input;

            Console.Write("Write an operator (+,-,*,/): ");
            while(symbol == null)
            {
                input = Console.ReadLine();
                if (symbolsValid.Contains(input))
                {
                    symbol = Convert.ToChar(input);
                } 
                else
                {
                    Console.WriteLine("Invalid operator, try again:");
                }
            }

            Console.WriteLine();
            return (char)symbol;
        }

        private static double calculation(double num1, char symbol, double num2)
        {
            double sum;
            switch(symbol)
            {
                case '+':
                    sum = num1 + num2;
                    break;
                case '-':
                    sum = num1 - num2;
                    break;
                case '*':
                    sum = num1 * num2;
                    break;
                case '/':
                    sum = num1 / num2;
                    break;
                default:
                    throw new ArgumentException("Symbol is unknown");
            }

            return sum;
        }

    }
}
