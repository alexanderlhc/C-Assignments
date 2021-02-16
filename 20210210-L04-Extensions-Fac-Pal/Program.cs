using System;
using System.Collections.Generic;
namespace _20210210_L04_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 8; i++)
            {
              Console.WriteLine("{0}!={1}", i, i.Factorial());
              Console.WriteLine("{0}^{1} = {2}", i, i+2, i.Power(i+2));
            }

            System.Console.WriteLine("===========");
            List<string> words = new List<string>() { "solos", "recursion", "ABBA" };
            words.ForEach(word => System.Console.WriteLine("{0} is a palindrome {1}", word, word.isPalindrome()));
        }



    }

    public static class MathExtension
    {
      public static int Factorial(this int n)
      {
        /* if (n == 0) return 1; */
        /* return n * (n-1).Factorial(); */
        /* return n * Factorial(n-1); */
        return (n == 0) ? 1 : n * (n-1).Factorial();
      }

      public static int Power(this int root, int exponent)
      {
        /* if(exponent == 0) return 1; */
        /* return root * root.Power(exponent-1); */
        return (exponent == 0)? 1 : root * root.Power(exponent-1);
      }
    }

    public static class TextExtension
    {
      public static bool isPalindrome(this string input)
      {
        return (input.Length == 0) ? true : isPalindrome(input, 0, input.Length - 1);
      }

      private static bool isPalindrome(string input, int i1, int i2)
      {
        if (i2 - i1 <= 1) return true;

        if (input[i1].Equals(input[i2]))
          return (i1 < i2) ? isPalindrome(input, ++i1, --i2) : true;
        else
          return false;
      }
    }
}
