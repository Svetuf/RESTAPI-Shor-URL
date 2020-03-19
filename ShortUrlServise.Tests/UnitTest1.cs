using NUnit.Framework;
using WebApplication15.Models;

namespace ShortUrlServise.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void AddShortLinkTEst()
        {
            DbInterface dbInterface = new DbInterface();

            string answer = dbInterface.GetShortUrl("test", "localhost");

            Assert.IsNotNull(answer);
            Assert.AreEqual(dbInterface.GetFullLink(answer), "test");
            Assert.AreEqual(dbInterface.TimeIsGone("test".GetHashCode()), false);
        }
    }
}