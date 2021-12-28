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
            
            Console.ReadKey();
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
