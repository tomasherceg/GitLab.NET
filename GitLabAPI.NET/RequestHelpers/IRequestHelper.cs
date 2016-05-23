using RestSharp;

namespace GitLabAPI.NET.RequestHelpers
{
    public interface IRequestHelper
    {
        string Url { get; }

        RestRequest GetRequest();
    }
}