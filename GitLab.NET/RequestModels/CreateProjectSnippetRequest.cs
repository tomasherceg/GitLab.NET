using GitLab.NET.ResponseModels;
using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class CreateProjectSnippetRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/snippets";

        private readonly string _code;
        private readonly string _fileName;
        private readonly uint _projectId;
        private readonly string _title;
        private readonly VisibilityLevel _visibilityLevel;

        public CreateProjectSnippetRequest(uint projectId, string title, string fileName, string code, VisibilityLevel visibilityLevel)
        {
            _projectId = projectId;
            _title = title;
            _fileName = fileName;
            _code = code;
            _visibilityLevel = visibilityLevel;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.POST);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameter("title", _title);
            result.AddParameter("file_name", _fileName);
            result.AddParameter("code", _code);
            result.AddParameter("visibility_level", _visibilityLevel);
            return result;
        }
    }
}