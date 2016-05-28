using GitLab.NET.ResponseModels;
using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class UpdateProjectSnippetRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/snippets/{id}";
        private readonly string _code;
        private readonly string _fileName;

        private readonly uint _id;
        private readonly uint _projectId;
        private readonly string _title;
        private readonly VisibilityLevel? _visibilityLevel;

        public UpdateProjectSnippetRequest(uint projectId, uint id, string title = null, string fileName = null, string code = null, VisibilityLevel? visibilityLevel = null)
        {
            _projectId = projectId;
            _id = id;
            _title = title;
            _fileName = fileName;
            _code = code;
            _visibilityLevel = visibilityLevel;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.PUT);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameterIfNotNull("id", _id, ParameterType.UrlSegment);
            result.AddParameterIfNotNull("title", _title);
            result.AddParameterIfNotNull("file_name", _fileName);
            result.AddParameterIfNotNull("code", _code);
            result.AddParameterIfNotNull("visibility_level", _visibilityLevel);
            return result;
        }
    }
}