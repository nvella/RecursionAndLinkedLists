using NUnit.Framework;
using Exercises;

namespace Tests
{
    public class Tests
    {
        LinkedList ll;
        private string[] data = {"asdf", "zxcv", "qwerty", "abc", "xyz", "aeiou", "foo", "bar", "hello", "world"};
    
        [SetUp]
        public void Init() {
            ll = new LinkedList();
            foreach (var s in data) {
                ll.AddToEnd(s);
            }
        }

        [TestCase("asdf", true)]
        [TestCase("foo", true)]
        [TestCase("world", true)]
        [TestCase("false", false)]
        public void Find(string searchTerm, bool ans) {
            Assert.AreEqual(ans, ll.Find(searchTerm));
        }
        
        [TestCase(2,"qwerty")]
        [TestCase(-1, null)]
        [TestCase(10, null)]
        public void GetNodeAt(int nodeNum, string ans) {
            Assert.AreEqual(ans, ll.GetNodeAt(nodeNum).Data);
        }
        
        [TestCase(10)]
        public void Count(int ans) {
            Assert.AreEqual(ans, ll.Count());
        }

        [Test]
        public void AddToStart() {
            ll.AddToStart("start");
            
            Assert.AreEqual(11, ll.Count());
            Assert.AreEqual("start", ll.GetNodeAt(0).Data);
        }

        [Test]
        public void AddToEnd() {
            ll.AddToEnd("end");
            
            Assert.AreEqual(11, ll.Count());
            Assert.AreEqual("end", ll.GetNodeAt(11).Data);
        }

        [TestCase("indexFour", 4, 4, 6, "indexFour", "aeiou")]
        [TestCase("indexTwelve", 12, 12, 10, "indexTwelve", null)]
        [TestCase("indexNegative", -1, 4, 6, "xyz", "foo")]
        public void AddNodeAt(string data, int index, int check1, int check2, string dataCheck1, string dataCheck2) {
            ll.AddNodeAt(data, index);
            
            Assert.AreEqual(dataCheck1, ll.GetNodeAt(check1).Data);
            Assert.AreEqual(dataCheck2, ll.GetNodeAt(check2).Data);
        }
        
        [Test]
        public void DeleteNodeAt() {
            ll.DeleteNodeAt(4);
            ll.DeleteNodeAt(100);

            Assert.AreEqual(false, ll.Find("xyz"));
            Assert.AreEqual("aeiou", ll.GetNodeAt(4).Data);
            
        }
    }
    
}
