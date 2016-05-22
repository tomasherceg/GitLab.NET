using RestSharp;

namespace GitLabAPI.Factories
{
    public interface IRestRequestFactory
    {
        IRestRequest Create();
    }
}