using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class CreateSystemHookRequest : IRequestModel
    {
        public const string Resource = "hooks";

        private readonly string _url;

        public CreateSystemHookRequest(string url)
        {
            _url = url;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.POST);
            result.AddParameter("url", _url);
            return result;
        }
    }
}