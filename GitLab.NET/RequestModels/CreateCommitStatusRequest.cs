using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class CreateCommitStatusRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/statuses/{commitSha}";

        private readonly string _commitSha;
        private readonly string _description;
        private readonly string _name;
        private readonly uint _projectId;
        private readonly string _refName;
        private readonly string _state;
        private readonly string _targetUrl;

        public CreateCommitStatusRequest(uint projectId, string commitSha, string state, string refName = null, string name = null, string targetUrl = null, string description = null)
        {
            _projectId = projectId;
            _commitSha = commitSha;
            _state = state;
            _refName = refName;
            _name = name;
            _targetUrl = targetUrl;
            _description = description;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.POST);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameter("commitSha", _commitSha, ParameterType.UrlSegment);
            result.AddParameter("state", _state);
            result.AddParameterIfNotNull("ref", _refName);
            result.AddParameterIfNotNull("name", _name);
            result.AddParameterIfNotNull("target_url", _targetUrl);
            result.AddParameterIfNotNull("description", _description);
            return result;
        }
    }
}