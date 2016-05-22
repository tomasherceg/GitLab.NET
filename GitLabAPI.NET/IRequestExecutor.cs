using System.Threading.Tasks;
using RestSharp;

namespace GitLabAPI.NET
{
    public interface IRequestExecutor
    {
        T Execute<T>(IRestRequest request) where T : new();
        Task<T> ExecuteAsync<T>(IRestRequest request) where T : new();
    }
}