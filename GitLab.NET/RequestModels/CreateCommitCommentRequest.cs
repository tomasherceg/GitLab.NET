using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class CreateCommitCommentRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/repository/commits/{commitSha}/comments";

        private readonly string _commitSha;
        private readonly uint? _line;
        private readonly string _lineType;
        private readonly string _note;
        private readonly string _path;
        private readonly uint _projectId;

        public CreateCommitCommentRequest(uint projectId, string commitSha, string note, string path = null, uint? line = null, string lineType = null)
        {
            _projectId = projectId;
            _commitSha = commitSha;
            _note = note;
            _path = path;
            _line = line;
            _lineType = lineType;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.POST);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameter("commitSha", _commitSha, ParameterType.UrlSegment);
            result.AddParameter("note", _note);
            result.AddParameterIfNotNull("path", _path);
            result.AddParameterIfNotNull("line", _line);
            result.AddParameterIfNotNull("line_type", _lineType);
            return result;
        }
    }
}