using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class UpdateBuildVariableRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/variables/{key}";
        private readonly string _key;

        private readonly uint _projectId;
        private readonly string _value;

        public UpdateBuildVariableRequest(uint projectId, string key, string value)
        {
            _projectId = projectId;
            _key = key;
            _value = value;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.PUT);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameter("key", _key, ParameterType.UrlSegment);
            result.AddParameter("value", _value);
            return result;
        }
    }
}