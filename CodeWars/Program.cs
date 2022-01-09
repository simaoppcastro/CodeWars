﻿using System;
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
            // Console.WriteLine(DuplicateCount(str: "aA11"));
            // Console.WriteLine(DuplicateCount(str: "aabBcde"));
            // Console.WriteLine(DuplicateCount(str: "Indivisibilities"));
            // Console.WriteLine(GetMiddle(s: "testing"));
            // Console.WriteLine(GetMiddle(s: "middle"));
            // Console.WriteLine(GetMiddle(s: "A"));
            // Console.WriteLine(StringEndWith("abc", "bc").ToString());
            // Console.WriteLine(StringEndWith("abc", "d").ToString());
            // Console.WriteLine(StringEndWith("samurai", "ra").ToString());

            Console.WriteLine(Accum("abcd"));

            Console.ReadKey();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static String Accum(string s)
        {
            String res = "";
            int j = 0;

            for (int x = 0; x < s.Length; x++)
            {
                j += 1;
                for (int i = 0; i < j; i++)
                {
                    if (i == 0) res += s[x].ToString().ToUpper();
                    else res += s[x].ToString().ToLower();
                }
                if (x < s.Length-1) res += "-";
            }

            return res;
        }

        /// <summary>
        /// Complete the solution so that it returns true if the first argument(string)
        /// passed in ends with the 2nd argument (also a string).
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ending"></param>
        /// <returns></returns>
        public static bool StringEndWith(string str, string ending)
        {
            // easy solution
            return str.EndsWith(ending);
        }

        /// <summary>
        /// You are going to be given a word. Your job is to return the middle character of the word.
        /// If the word's length is odd, return the middle character.
        /// If the word's length is even, return the middle 2 characters.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string GetMiddle(string s)
        {
            if (s.Length % 2 != 0) return s[s.Length / 2].ToString();
            else return s[s.Length / 2 - 1].ToString() + s[s.Length / 2].ToString();
        }

        /// <summary>
        /// Write a function that will return the count of distinct case-insensitive alphabetic
        /// characters and numeric digits that occur more than once in the input string.
        /// The input string can be assumed to contain only alphabets
        /// (both uppercase and lowercase) and numeric digits.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int DuplicateCount(string str)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            int result = 0;

            foreach (var ch in str.ToLower())
            {
                if (!dict.ContainsKey(ch)) dict.Add(ch, 1);
                else dict[ch] += 1;
            }

            foreach (var item in dict.Values) if (item > 1) result += 1;
            
            return result;

            // simple solution (with Linq)
            // return str.ToLower().GroupBy(c => c).Count(c => c.Count() > 1);
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
