using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetProjectSnippetsRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/snippets";

        private readonly uint _projectId;

        public GetProjectSnippetsRequest(uint projectId)
        {
            _projectId = projectId;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.GET);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            return result;
        }
    }
}