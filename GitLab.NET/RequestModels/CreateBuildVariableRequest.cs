using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class CreateBuildVariableRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/variables";

        private readonly string _key;
        private readonly uint _projectId;
        private readonly string _value;

        public CreateBuildVariableRequest(uint projectId, string key, string value)
        {
            _projectId = projectId;
            _key = key;
            _value = value;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.POST);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameter("key", _key);
            result.AddParameter("value", _value);
            return result;
        }
    }
}