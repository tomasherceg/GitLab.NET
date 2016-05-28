using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetRepositoryRawBlobContentRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/repository/raw_blobs/{sha}";

        private readonly uint _projectId;
        private readonly string _sha;

        public GetRepositoryRawBlobContentRequest(uint projectId, string sha)
        {
            _projectId = projectId;
            _sha = sha;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.GET);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameter("sha", _sha, ParameterType.UrlSegment);
            return result;
        }
    }
}