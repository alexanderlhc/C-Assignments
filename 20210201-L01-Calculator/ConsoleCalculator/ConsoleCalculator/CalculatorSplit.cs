using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
  class CalculatorSplit
  {
    static void Main(string[] args)
    {
      string[] samples = {"1 + 1", "1 - 1"};
      char[] operators = {'+', '-'};

      foreach (string expression in samples)
      {
        string[] parts = expression.Split(" ");
        double num1 = Convert.ToDouble(parts[0]);
        double num2 = Convert.ToDouble(parts[2]);
        char operatr = Convert.ToChar(parts[1]);
        double result = calculate(num1, num2, operatr);
        Console.WriteLine("{0} {1} {2} = {3}", num1, operatr, num2, result);
      }

      Console.ReadKey();
    }

      private static double calculate(double num1, double num2, char operatr)
      {
        double result;

        switch (operatr)
        {
            case '+':
              result = num1 + num2;
              break;
            case '-':
              result = num1 - num2;
              break;
            default:
              throw new ArgumentException("Unknown operator");
        }

        return result;
      }
    }
}


