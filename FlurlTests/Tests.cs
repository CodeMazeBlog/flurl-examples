using System.Net.Http;
using Flurl.Http.Testing;
using FlurlExamples;
using FlurlExamples.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlurlTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void GetRepositories_ShouldHaveBeenCalled_AtLeastOnce()
        {
            using (var httpTest = new HttpTest())
            {
                var flurlRequestHandler = new FlurlRequestHandler();
                var result = flurlRequestHandler.GetRepositories().Result;

                httpTest.ShouldHaveCalled(RequestConstants.BaseUrl + "user" + "/repos")
                    .WithVerb(HttpMethod.Get)
                    .Times(1);
            }
        }

        [TestMethod]
        public void CreateRepository_ShouldHaveBeenCalled_AtLeastOnce()
        {
            using (var httpTest = new HttpTest())
            {
                var flurlRequestHandler = new FlurlRequestHandler();
                var result = flurlRequestHandler.CreateRepository("CodeMazeBlog", "Test").Result;

                httpTest.ShouldHaveCalled(RequestConstants.BaseUrl + "user" + "/repos")
                    .WithVerb(HttpMethod.Post)
                    .Times(1);
            }
        }
    }
}
