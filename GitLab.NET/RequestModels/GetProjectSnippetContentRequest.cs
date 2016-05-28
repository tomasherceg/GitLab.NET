using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetProjectSnippetContentRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/snippets/{id}/raw";

        private readonly uint _id;
        private readonly uint _projectId;

        public GetProjectSnippetContentRequest(uint id, uint projectId)
        {
            _id = id;
            _projectId = projectId;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.GET);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameter("id", _id, ParameterType.UrlSegment);
            return result;
        }
    }
}