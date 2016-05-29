using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetTagRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/repository/tags/{tagName}";

        private readonly uint _projectId;
        private readonly string _tagName;

        public GetTagRequest(uint projectId, string tagName)
        {
            _projectId = projectId;
            _tagName = tagName;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.GET);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameter("tagName", _tagName, ParameterType.UrlSegment);
            return result;
        }
    }
}