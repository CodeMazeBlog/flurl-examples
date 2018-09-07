using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using FlurlExamples.Constants;
using FlurlExamples.Model;

namespace FlurlExamples
{
    public class FlurlRequestHandler : IRequestHandler
    {
        private static string _githubUsername;
        private static string _githubPassword;

        public FlurlRequestHandler()
        {
            _githubUsername = Environment.GetEnvironmentVariable("GITHUB_USERNAME");
            _githubPassword = Environment.GetEnvironmentVariable("GITHUB_PASS");
        }

        public async Task<List<Repository>> GetRepositories()
        {
            var url = Url.Combine(RequestConstants.BaseUrl, "/user/repos");

            var result = await url
                .WithHeader(RequestConstants.UserAgent, RequestConstants.UserAgentValue)
                .WithBasicAuth(_githubUsername, _githubPassword)
                .GetJsonAsync<List<Repository>>();

            return result;
        }

        public async Task<Repository> CreateRepository(string user, string repository)
        {
            var url = Url.Combine(RequestConstants.BaseUrl, "/user/repos");
            var repo = new Repository
            {
                Name = repository,
                FullName = $"{user}/{repository}",
                Description = "Generic description",
                Private = false
            };

            var result = await url
                .WithHeader(RequestConstants.UserAgent, RequestConstants.UserAgentValue)
                .WithBasicAuth(_githubUsername, _githubPassword)
                .PostJsonAsync(repo)
                .ReceiveJson<Repository>();

            return result;
        }

        public async Task<HttpResponseMessage> DeleteRepository(string user, string repository)
        {
            var url = Url.Combine(RequestConstants.BaseUrl, $"/repos/{user}/{repository}");

            var result = await url
                .WithHeader(RequestConstants.UserAgent, RequestConstants.UserAgentValue)
                .WithBasicAuth(_githubUsername, _githubPassword)
                .DeleteAsync();

            return result;
        }
    }
}