using System.Net.Http;
using Flurl;
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
                var result = flurlRequestHandler.GetRepositories();

                httpTest.ShouldHaveCalled(Url.Combine(RequestConstants.BaseUrl, "user", "repos"))
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
                var result = flurlRequestHandler.CreateRepository("CodeMazeBlog", "Test");

                httpTest.ShouldHaveCalled(Url.Combine(RequestConstants.BaseUrl, "user", "repos"))
                    .WithVerb(HttpMethod.Post)
                    .Times(1);
            }
        }

        [TestMethod]
        public void EditRepository_ShouldHaveBeenCalled_AtLeastOnce()
        {
            using (var httpTest = new HttpTest())
            {
                var flurlRequestHandler = new FlurlRequestHandler();
                var result = flurlRequestHandler.EditRepository("CodeMazeBlog", "Test");

                httpTest.ShouldHaveCalled(Url.Combine(RequestConstants.BaseUrl, "repos", "CodeMazeBlog", "Test"))
                    .WithVerb(new HttpMethod("PATCH"))
                    .Times(1);
            }
        }

        [TestMethod]
        public void DeleteRepository_ShouldHaveBeenCalled_AtLeastOnce()
        {
            using (var httpTest = new HttpTest())
            {
                var flurlRequestHandler = new FlurlRequestHandler();
                var result = flurlRequestHandler.DeleteRepository("CodeMazeBlog", "Test");

                httpTest.ShouldHaveCalled(Url.Combine(RequestConstants.BaseUrl, "repos", "CodeMazeBlog", "Test"))
                    .WithVerb(HttpMethod.Delete)
                    .Times(1);
            }
        }
    }
}
