using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class DeleteSystemHookRequest : IRequestModel
    {
        public const string Resource = "hooks/{hookId}";

        private readonly uint _hookId;

        public DeleteSystemHookRequest(uint hookId)
        {
            _hookId = hookId;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.DELETE);
            result.AddParameter("hookId", _hookId, ParameterType.UrlSegment);
            return result;
        }
    }
}