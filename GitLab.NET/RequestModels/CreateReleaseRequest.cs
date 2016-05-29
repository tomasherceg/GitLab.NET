using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class CreateReleaseRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/repository/tags/{tagName}/release";

        private readonly string _description;
        private readonly uint _projectId;
        private readonly string _tagName;

        public CreateReleaseRequest(uint projectId, string tagName, string description)
        {
            _projectId = projectId;
            _tagName = tagName;
            _description = description;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.POST);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameter("tagName", _tagName, ParameterType.UrlSegment);
            result.AddParameter("description", _description);
            return result;
        }
    }
}