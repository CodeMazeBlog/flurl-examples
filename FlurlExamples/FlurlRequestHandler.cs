using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using FlurlExamples.Constants;

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

        public async Task<List<Authorization>> GetAuthorizations()
        {
            var url = Url.Combine(RequestConstants.BaseUrl, "/authorizations");

            var result = await url
                .WithHeader(RequestConstants.UserAgent, RequestConstants.UserAgentValue)
                .WithBasicAuth(_githubUsername, _githubPassword)
                .GetJsonAsync<List<Authorization>>();

            return result;
        }
    }
}