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

        [Test]
        public void test_IsPangram1()
        {
            Assert.AreEqual(true, CodeWars.Program.IsPangram("The quick brown fox jumps over the lazy dog."));
        }

        [Test]
        public void test_IsPangram2()
        {
            Assert.AreEqual(true, CodeWars.Program.IsPangram("BCDEFGHIJKLMNOPQRSTUVWXYZa"));
        }

        [Test]
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

        [Test, TestCaseSource("testCases")]
        public void test_IsPangram4(bool expected, string str) => Assert.AreEqual(expected, CodeWars.Program.IsPangram(str));
    }
}