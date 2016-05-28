using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetRepositoryRawFileContentRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/repository/blobs/{sha}";
        private readonly string _filePath;

        private readonly uint _projectId;
        private readonly string _sha;

        public GetRepositoryRawFileContentRequest(uint projectId, string sha, string filePath)
        {
            _projectId = projectId;
            _sha = sha;
            _filePath = filePath;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.GET);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameter("sha", _sha, ParameterType.UrlSegment);
            result.AddParameter("filepath", _filePath);
            return result;
        }
    }
}