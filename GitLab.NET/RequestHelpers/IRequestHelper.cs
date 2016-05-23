using RestSharp;

namespace GitLab.NET.RequestHelpers
{
    public interface IRequestHelper
    {
        RestRequest GetRequest();
    }
}