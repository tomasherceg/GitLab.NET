using RestSharp;

namespace GitLabAPI.NET.RequestHelpers
{
    public interface IRequestHelper
    {
        RestRequest GetRequest();
    }
}