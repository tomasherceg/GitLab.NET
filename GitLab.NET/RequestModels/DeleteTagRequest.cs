using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class DeleteTagRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/repository/tags/{tagName}";

        private readonly uint _projectId;
        private readonly string _tagName;

        public DeleteTagRequest(uint projectId, string tagName)
        {
            _projectId = projectId;
            _tagName = tagName;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.DELETE);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameter("tagName", _tagName, ParameterType.UrlSegment);
            return result;
        }
    }
}