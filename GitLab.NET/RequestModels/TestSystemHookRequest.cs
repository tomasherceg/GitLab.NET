using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class TestSystemHookRequest : IRequestModel
    {
        public const string Resource = "hooks/{hookId}";

        private readonly uint _hookId;

        public TestSystemHookRequest(uint hookId)
        {
            _hookId = hookId;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.GET);
            result.AddParameter("hookId", _hookId, ParameterType.UrlSegment);
            return result;
        }
    }
}