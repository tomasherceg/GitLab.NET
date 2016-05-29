using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class CreateFileRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/repository/files";

        private readonly string _branchName;
        private readonly string _commitMessage;
        private readonly string _content;
        private readonly string _encoding;
        private readonly string _filePath;
        private readonly uint _projectId;

        public CreateFileRequest(uint projectId, string filePath, string branchName, string content, string commitMessage, string encoding = null)
        {
            _projectId = projectId;
            _filePath = filePath;
            _branchName = branchName;
            _content = content;
            _commitMessage = commitMessage;
            _encoding = encoding;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.POST);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameter("file_path", _filePath);
            result.AddParameter("branch_name", _branchName);
            result.AddParameter("content", _content);
            result.AddParameter("commit_message", _commitMessage);
            result.AddParameterIfNotNull("encoding", _encoding);
            return result;
        }
    }
}