using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetFileRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/repository/files";

        private readonly string _filePath;
        private readonly uint _projectId;
        private readonly string _refName;

        public GetFileRequest(uint projectId, string filePath, string refName)
        {
            _projectId = projectId;
            _filePath = filePath;
            _refName = refName;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.GET);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameter("file_path", _filePath);
            result.AddParameter("ref", _refName);
            return result;
        }
    }
}