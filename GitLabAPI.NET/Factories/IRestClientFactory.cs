using RestSharp;

namespace GitLabAPI.NET.Factories
{
    public interface IRestClientFactory
    {
        IRestClient Create();
    }
}
