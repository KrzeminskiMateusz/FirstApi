using NUnit.Framework;
using System.Net.Http;

namespace Tests
{
    public class Tests
    {
        //private readonly TestServer _server;
        private readonly HttpClient _client;

        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}