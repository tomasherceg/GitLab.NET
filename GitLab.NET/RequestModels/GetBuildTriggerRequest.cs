using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetBuildTriggerRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/triggers/{token}";

        private readonly uint _projectId;
        private readonly string _token;

        public GetBuildTriggerRequest(uint projectId, string token)
        {
            _projectId = projectId;
            _token = token;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.GET);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameter("token", _token, ParameterType.UrlSegment);
            return result;
        }
    }
}