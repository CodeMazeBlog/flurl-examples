using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FlurlExamples.Model;

namespace FlurlExamples
{
    public interface IRequestHandler
    {
        Task<List<Repository>> GetRepositories();
        Task<Repository> CreateRepository(string user, string repository);
        Task<Repository> EditRepository(string user, string repository);
        Task<HttpResponseMessage> DeleteRepository(string user, string repository);
    }
}