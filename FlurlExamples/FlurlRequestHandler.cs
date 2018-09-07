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
        private static string _githubToken;

        public FlurlRequestHandler()
        {
            //keeping sensitive information in environment variables
            //never, ever leave secret information in the code or it might end up in some public repo
            _githubUsername = Environment.GetEnvironmentVariable("GITHUB_USERNAME");
            _githubPassword = Environment.GetEnvironmentVariable("GITHUB_PASS");
            _githubToken = Environment.GetEnvironmentVariable("GITHUB_TOKEN");
        }

        public Task<List<Repository>> GetRepositories()
        {
            var result = RequestConstants.BaseUrl
                .AppendPathSegments("user", "repos")
                .WithHeader(RequestConstants.UserAgent, RequestConstants.UserAgentValue)
                //.WithBasicAuth(_githubUsername, _githubPassword) //alternative way of logging in (basic auth)
                .WithOAuthBearerToken(_githubToken)
                .GetJsonAsync<List<Repository>>();

            return result;
        }

        public Task<Repository> CreateRepository(string user, string repository)
        {
            var repo = new Repository
            {
                Name = repository,
                FullName = $"{user}/{repository}",
                Description = "Generic description",
                Private = false
            };

            var result = RequestConstants.BaseUrl
                .AppendPathSegments("user", "repos")
                .WithHeader(RequestConstants.UserAgent, RequestConstants.UserAgentValue)
                .WithOAuthBearerToken(_githubToken)
                .PostJsonAsync(repo)
                .ReceiveJson<Repository>();

            return result;
        }

        public Task<Repository> EditRepository(string user, string repository)
        {
            var repo = new Repository
            {
                Name = repository,
                FullName = $"{user}/{repository}",
                Description = "Modified repository",
                Private = false
            };

            var result = RequestConstants.BaseUrl
                .AppendPathSegments("repos", user, repository)
                .WithHeader(RequestConstants.UserAgent, RequestConstants.UserAgentValue)
                .WithOAuthBearerToken(_githubToken)
                .PatchJsonAsync(repo)
                .ReceiveJson<Repository>();

            return result;
        }

        public Task<HttpResponseMessage> DeleteRepository(string user, string repository)
        {
            var result = RequestConstants.BaseUrl
                .AppendPathSegments("repos", user, repository)
                .WithHeader(RequestConstants.UserAgent, RequestConstants.UserAgentValue)
                .WithOAuthBearerToken(_githubToken)
                .DeleteAsync();

            return result;
        }
    }
}