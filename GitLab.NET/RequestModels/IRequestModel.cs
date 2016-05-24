using RestSharp;

namespace GitLab.NET.RequestModels
{
    public interface IRequestModel
    {
        RestRequest GetRequest();
    }
}
