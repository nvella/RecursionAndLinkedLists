using NUnit.Framework;
using Exercises;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        RecursionLib rc;

         private static List<int>[] _countTestLists = {  new List<int> {1,2,3},
                                                        new List<int> {1,2,3,4},
                                                        new List<int> {1,2,3,4,5,6,7,8,9,10,11,12}
        };
        
        [SetUp]
        public void Setup()
        {
            rc = new RecursionLib();
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 6)]
        [TestCase(0, 1)]
        [TestCase(5, 120)]
        [TestCase(6, 720)]
        public void FactorialRecTest(int num, int ans) {
            Assert.AreEqual(ans, rc.FactorialRec(num));
        }

        [TestCase("abc", "cba")]
        [TestCase("qwerty", "ytrewq")]
        [TestCase("aaa", "aaa")]
        [TestCase("", "")]
        [TestCase("b", "b")]
        [TestCase("dog and pig", "gip dna god")]
        public void WordReverseRecTest(string word, string ans) {
            Assert.AreEqual(ans, rc.WordReverseRec(word, ""));
        }

        [Test, TestCaseSource("_countTestLists")]
        public void CountRecTest(List<int> ans) {
                Assert.AreEqual(ans, rc.CountRec(ans.Count, new List<int>()));    
        }

        [TestCase(2, 2, 4)]
        [TestCase(2, 3, 8)]
        [TestCase(2, 4, 16)]
        [TestCase(3, 2, 9)]
        [TestCase(3, 3, 27)]
        [TestCase(4, 2, 16)]
        [TestCase(10, 10, 10000000000)]
        public void ExponentialRecTest(int num, int pow, long ans) {
            Assert.AreEqual(ans, rc.ExponentialRec(num, pow));
        }
    }
}