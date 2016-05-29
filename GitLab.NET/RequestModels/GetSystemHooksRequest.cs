using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetSystemHooksRequest : IRequestModel
    {
        public const string Resource = "hooks";

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.GET);
            return result;
        }
    }
}