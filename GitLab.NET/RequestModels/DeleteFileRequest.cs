using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class DeleteFileRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/repository/files";

        private readonly string _branchName;
        private readonly string _commitMessage;
        private readonly string _filePath;
        private readonly uint _projectId;

        public DeleteFileRequest(uint projectId, string filePath, string branchName, string commitMessage)
        {
            _projectId = projectId;
            _filePath = filePath;
            _branchName = branchName;
            _commitMessage = commitMessage;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.DELETE);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameter("file_path", _filePath);
            result.AddParameter("branch_name", _branchName);
            result.AddParameter("commit_message", _commitMessage);
            return result;
        }
    }
}