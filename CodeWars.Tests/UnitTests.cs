using NUnit.Framework;
using CodeWars;
using System;
using System.Linq;

namespace CodeWars.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        #region GetMiddle

        /// <summary>
        /// helper function to test Method GetMiddle
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string GetMiddleT(string s)
        {
            int middle = s.Length / 2;
            if (s.Length % 2 == 0) return s[middle - 1].ToString() + s[middle].ToString();
            else return s[middle].ToString();
        }

        [Test, Description("Return the middle fo the string (random tests).")]
        public static void TestGetMiddleWithRandomStrings()
        {
            string alph = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random rnd = new Random();

            for (int i = 0; i < 50; i++)
            {
                string randomString = "";
                int rando = rnd.Next(1, 1000);
                for (int j = 0; j < rando; j++)
                {
                    int n = rnd.Next(0, alph.Length);
                    randomString += alph[n];
                }
                Assert.AreEqual(GetMiddleT(randomString), CodeWars.Program.GetMiddle(randomString));
            }
        }

        #endregion

        #region DuplicateCount

        [Test, Description("Count the number of Duplicates.")]
        public void TestDuplicateCount()
        {
            Assert.AreEqual(0, CodeWars.Program.DuplicateCount(""));
            Assert.AreEqual(0, CodeWars.Program.DuplicateCount("abcde"));
            Assert.AreEqual(2, CodeWars.Program.DuplicateCount("aabbcde"));
            Assert.AreEqual(2, CodeWars.Program.DuplicateCount("aabBcde"), "should ignore case");
            Assert.AreEqual(1, CodeWars.Program.DuplicateCount("Indivisibility"));
            Assert.AreEqual(2, CodeWars.Program.DuplicateCount("Indivisibilities"), "characters may not be adjacent");
        }

        #endregion

        #region FindSmallestInt

        [Test, Description("Given an array of integers your solution should find the smallest integer.")]
        public void TestFindSmallestInt1()
        {
            Assert.AreEqual(11, CodeWars.Program.FindSmallestInt(args: new int[] { 78, 56, 232, 12, 11, 43 }));
        }

        [Test, Description("Given an array of integers your solution should find the smallest integer.")]
        public void TestFindSmallestInt2()
        {
            Assert.AreEqual(-33, CodeWars.Program.FindSmallestInt(args: new int[] { 78, 56, -2, 12, 8, -33 }));
        }

        #endregion

        #region MakeNegative

        Random r = new Random();

        [Test, Description("given a number and have to make it negative. But maybe the number is already negative")]
        public void RandomPositiveTest()
        {
            int number = r.Next(1, 101);
            Assert.AreEqual(-Math.Abs(number), CodeWars.Program.MakeNegative(number));
        }

        [Test, Description("given a number and have to make it negative. But maybe the number is already negative")]
        public void RandomNegativeTest()
        {
            int number = r.Next(-100, 0);
            Assert.AreEqual(-Math.Abs(number), CodeWars.Program.MakeNegative(number));
        }

        #endregion

        #region DescendingOrder

        [Test, Description("Order Descending input int argument!")]
        public void Test0()
        {
            Assert.AreEqual(0, CodeWars.Program.DescendingOrder(0));
        }

        [Test, Description("Order Descending input int argument!")]
        public void Test1()
        {
            Assert.AreEqual(1, CodeWars.Program.DescendingOrder(1));
        }

        [Test, Description("Order Descending input int argument!")]
        public void Test15()
        {
            Assert.AreEqual(51, CodeWars.Program.DescendingOrder(15));
        }

        [Test, Description("Order Descending input int argument!")]
        public void Test1021()
        {
            Assert.AreEqual(2110, CodeWars.Program.DescendingOrder(1021));
        }

        [Test, Description("Order Descending input int argument!")]
        public void Test123456789()
        {
            Assert.AreEqual(987654321, CodeWars.Program.DescendingOrder(123456789));
        }

        [Test, Description("Order Descending input int argument!")]
        public void TestNegatives()
        {
            Assert.AreEqual(-987654321, CodeWars.Program.DescendingOrder(-123456789));
        }

        #endregion

        #region ValidatePin

        [Test, Description("ValidatePin should return false for pins with length other than 4 or 6")]
        public void LengthTest()
        {
            Assert.AreEqual(false, CodeWars.Program.ValidatePin("1"), "Wrong output for \"1\"");
            Assert.AreEqual(false, CodeWars.Program.ValidatePin("12"), "Wrong output for \"12\"");
            Assert.AreEqual(false, CodeWars.Program.ValidatePin("123"), "Wrong output for \"123\"");
            Assert.AreEqual(false, CodeWars.Program.ValidatePin("12345"), "Wrong output for \"12345\"");
            Assert.AreEqual(false, CodeWars.Program.ValidatePin("1234567"), "Wrong output for \"1234567\"");
            Assert.AreEqual(false, CodeWars.Program.ValidatePin("-1234"), "Wrong output for \"-1234\"");
            Assert.AreEqual(false, CodeWars.Program.ValidatePin("-12345"), "Wrong output for \"-12345\"");
            Assert.AreEqual(false, CodeWars.Program.ValidatePin("1.234"), "Wrong output for \"1.234\"");
            Assert.AreEqual(false, CodeWars.Program.ValidatePin("-1.234"), "Wrong output for \"-1.234\"");
            Assert.AreEqual(false, CodeWars.Program.ValidatePin("00000000"), "Wrong output for \"00000000\"");
        }

        [Test, Description("ValidatePin should return false for pins which contain characters other than digits")]
        public void NonDigitTest()
        {
            Assert.AreEqual(false, CodeWars.Program.ValidatePin("a234"), "Wrong output for \"a234\"");
            Assert.AreEqual(false, CodeWars.Program.ValidatePin(".234"), "Wrong output for \".234\"");
        }

        [Test, Description("ValidatePin should return true for valid pins")]
        public void ValidTest()
        {
            Assert.AreEqual(true, CodeWars.Program.ValidatePin("1234"), "Wrong output for \"1234\"");
            Assert.AreEqual(true, CodeWars.Program.ValidatePin("0000"), "Wrong output for \"0000\"");
            Assert.AreEqual(true, CodeWars.Program.ValidatePin("1111"), "Wrong output for \"1111\"");
            Assert.AreEqual(true, CodeWars.Program.ValidatePin("123456"), "Wrong output for \"123456\"");
            Assert.AreEqual(true, CodeWars.Program.ValidatePin("098765"), "Wrong output for \"098765\"");
            Assert.AreEqual(true, CodeWars.Program.ValidatePin("000000"), "Wrong output for \"000000\"");
            Assert.AreEqual(true, CodeWars.Program.ValidatePin("090909"), "Wrong output for \"090909\"");
        }

        [Test, Description("ValidatePin should return false in various edge cases")]
        public void EdgeCaseTest()
        {
            foreach (string s in edgeCaseStrings)
                Assert.AreEqual(false, CodeWars.Program.ValidatePin(s), String.Format("Wrong output for \"{0}\"", s));
        }

        public readonly string[] edgeCaseStrings = new string[]{
            "",
            "123",
            "12345",
            "1234567",
            "1234567890",
            "1234x",
            "123456x",
            "12.0",
            "1234.0",
            "123456.0",
            "123\n",
            "1234\n",
            "09876\n",
            "098765\n",
            "-111",
            "111-",
            "-44444",
            "44444-",
            "+111",
            "+88888",
            "+1111",
            "-2018",
            "+234567",
            "-234567",
            "123/",
            "456:",
            "9?9?",
        };

        #endregion

        #region IsPangram
        [Test, Description("A pangram is a sentence that contains every single letter of the alphabet at least once")]
        public void test_IsPangram1()
        {
            Assert.AreEqual(true, CodeWars.Program.IsPangram("The quick brown fox jumps over the lazy dog."));
        }

        [Test, Description("A pangram is a sentence that contains every single letter of the alphabet at least once")]
        public void test_IsPangram2()
        {
            Assert.AreEqual(true, CodeWars.Program.IsPangram("BCDEFGHIJKLMNOPQRSTUVWXYZa"));
        }

        [Test, Description("A pangram is a sentence that contains every single letter of the alphabet at least once")]
        public void test_IsPangram3()
        {
            Assert.AreEqual(false, CodeWars.Program.IsPangram("BCDEFGHIJKLMNOPQRSTUVWXYZ"));
        }

        private static Random rnd = new Random();

        private static object[][] testCases = new object[][]
        {
            new object[] {false, "This isn't a pangram!"},
            new object[] {false, "abcdefghijklmopqrstuvwxyz "},
            new object[] {false, "aaaaaaaaaaaaaaaaaaaaaaaaaa"},
            new object[] {false, "Detect Pangram"},
            new object[] {false, "A pangram is a sentence that contains every single letter of the alphabet at least once."},
            new object[] {true, "Cwm fjord bank glyphs vext quiz"},
            new object[] {true, "Pack my box with five dozen liquor jugs."},
            new object[] {true, "How quickly daft jumping zebras vex."},
            new object[] {true, "ABCD45EFGH,IJK,LMNOPQR56STUVW3XYZ"},
            new object[] {true, "AbCdEfGhIjKlM zYxWvUtSrQpOn"},
            new object[] {true, "Raw Danger! (Zettai Zetsumei Toshi 2) for the PlayStation 2 is a bit queer, but an alright game I guess, uh... CJ kicks and vexes Tenpenny precariously? This should be a pangram now, probably."},
        }.OrderBy(x => rnd.Next()).ToArray();

        [Test, TestCaseSource("testCases"), Description("A pangram is a sentence that contains every single letter of the alphabet at least once")]
        public void test_IsPangram4(bool expected, string str) => Assert.AreEqual(expected, CodeWars.Program.IsPangram(str));

        #endregion
    }
}