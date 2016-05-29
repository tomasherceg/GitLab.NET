using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetCommitCommentsRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/repository/commits/{commitSha}/comments";

        private readonly string _commitSha;
        private readonly uint _projectId;

        public GetCommitCommentsRequest(uint projectId, string commitSha)
        {
            _projectId = projectId;
            _commitSha = commitSha;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.GET);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameter("commitSha", _commitSha, ParameterType.UrlSegment);
            return result;
        }
    }
}