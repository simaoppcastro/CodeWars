using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine(IsPangram("The quick brown fox jumps over the lazy dog."));       // True
            // Console.WriteLine(ValidatePin("a234"));
            // Console.WriteLine(DescendingOrder(123456));
            // Console.WriteLine(DescendingOrder(-123456789));
            // Console.WriteLine(MakeNegative(-1));
            // Console.WriteLine(MakeNegative(0));
            // Console.WriteLine(MakeNegative(5));
            // Console.WriteLine(FindSmallestInt(new int[] { 78, 56, 232, 12, 11, 43 }));

            Console.ReadKey();
        }

        /// <summary>
        /// Given an array of integers your solution should find the smallest integer.
        /// Example: Given [34, -345, -1, 100] your solution will return -345
        /// You can assume, for the purpose of this kata, that the supplied array will not be empty.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static int FindSmallestInt(int[] args)
        {
            if (args.Length > 0)
            {
                List<int> result = args.ToList<int>();
                result.Sort();
                return result[0];
            }
            else return -1;

            // another simple solution
            // return args.Min();
        }

        /// <summary>
        /// In this simple assignment you are given a number and have to make it negative. But maybe the number is already negative?
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int MakeNegative(int number)
        {
            if (number >= 0) return number * -1;
            else return number;

            // simple solution (one line of code)
            // return -Math.Abs(number);
        }

        /// <summary>
        /// Your task is to make a function that can take any non-negative integer as 
        /// an argument and return it with its digits in descending order. 
        /// Essentially, rearrange the digits to create the highest possible number.
        /// Examples: Input: 42145 Output: 54421
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int DescendingOrder(int num)
        {
            #region negatives control
            // this don´t make any sense (reverse a negative int ????)
            // for this function, it was assumed that, if the input is negative, the output will be as well
            bool negative;
            if (num.ToString().Contains('-'))
            {
                num = int.Parse(num.ToString().Replace("-", String.Empty));
                negative = true;
            }
            else negative = false;
            #endregion

            List<char> l_numbers = new List<char>();
            l_numbers.AddRange(num.ToString().ToCharArray());

            List<int> i_numbers = l_numbers.Select(c => int.Parse(c.ToString())).ToList();
            i_numbers.Sort();
            i_numbers.Reverse();

            string result = "";
            foreach (var item in i_numbers) result += item;

            // negative int result
            if (negative) return int.Parse(result) * -1;
            // positive int result
            else return int.Parse(result);

            // clean solution (without consideration on negative integer input argument)
            // return int.Parse(string.Concat(num.ToString().OrderByDescending(x => x)));
        }


        /// <summary>
        /// ATM machines allow 4 or 6 digit PIN codes and PIN codes cannot contain anything but exactly 4 digits or exactly 6 digits.
        /// If the function is passed a valid PIN string, return true, else return false.
        /// only numbers; with length of 4 or 6
        /// </summary>
        /// <param name="pin"></param>
        /// <returns></returns>
        public static bool ValidatePin(string pin)
        {
            if ((pin.Length == 4 || pin.Length == 6) && pin.All(char.IsDigit)) return true;
            else return false;
        }

        /// <summary>
        /// A pangram is a sentence that contains every single letter of the alphabet at least once. For example, the sentence 
        /// "The quick brown fox jumps over the lazy dog" is a pangram, because it uses the letters A-Z at least once (case is irrelevant).
        /// Given a string, detect whether or not it is a pangram.Return True if it is, False if not.Ignore numbers and punctuation.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsPangram(string str)
        {
            List<char> l_alphabet = new List<char>();
            l_alphabet.AddRange("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower());

            foreach (var item in str.ToLower())
            {
                if (l_alphabet.Contains(item)) l_alphabet.Remove(item);
            }

            if (l_alphabet.Count == 0) return true;
            else return false;
        }

    }
}
