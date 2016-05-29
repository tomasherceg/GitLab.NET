using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetCommitStatusRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/repository/commits/{commitSha}/statuses";

        private readonly bool? _all;
        private readonly string _commitSha;
        private readonly string _name;
        private readonly uint _projectId;
        private readonly string _refName;
        private readonly string _stage;

        public GetCommitStatusRequest(uint projectId, string commitSha, string refName = null, string stage = null, string name = null, bool? all = null)
        {
            _projectId = projectId;
            _commitSha = commitSha;
            _refName = refName;
            _stage = stage;
            _name = name;
            _all = all;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.GET);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameter("commitSha", _commitSha, ParameterType.UrlSegment);
            result.AddParameterIfNotNull("ref_name", _refName);
            result.AddParameterIfNotNull("stage", _stage);
            result.AddParameterIfNotNull("name", _name);
            result.AddParameterIfNotNull("all", _all);
            return result;
        }
    }
}