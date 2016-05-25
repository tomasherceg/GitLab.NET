using RestSharp;

namespace GitLab.NET
{
    public interface IRequestModel
    {
        RestRequest GetRequest();
    }
}