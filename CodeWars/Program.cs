using System;
using System.Collections.Generic;

namespace CodeWars
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsPangram("The quick brown fox jumps over the lazy dog."));       // True
            Console.WriteLine(IsPangram("ABCDEFGHIJKLMNOPQRSTUVWXYZ"));                         // True
            Console.WriteLine(IsPangram("aBCDEFGHIJKLMNOPQRSTUVWXYZ"));                         // True
            Console.WriteLine(IsPangram("BCDEFGHIJKLMNOPQRSTUVWXYZ"));                          // False
            Console.WriteLine(IsPangram("BCDEFGHIJKLMNOPQRSTUVWXYZa"));                         // True
            Console.ReadKey();
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
