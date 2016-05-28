using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetBuildVariableRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/variables/{key}";
        private readonly string _key;

        private readonly uint _projectId;

        public GetBuildVariableRequest(uint projectId, string key)
        {
            _projectId = projectId;
            _key = key;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.GET);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameter("key", _key, ParameterType.UrlSegment);
            return result;
        }
    }
}