using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetRepositoryFileArchiveRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/repository/archive";

        private readonly uint _projectId;
        private readonly string _sha;

        public GetRepositoryFileArchiveRequest(uint projectId, string sha = null)
        {
            _projectId = projectId;
            _sha = sha;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.GET);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameterIfNotNull("sha", _sha);
            return result;
        }
    }
}