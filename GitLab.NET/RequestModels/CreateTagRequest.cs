using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class CreateTagRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/repository/tags";

        private readonly string _message;
        private readonly uint _projectId;
        private readonly string _refName;
        private readonly string _releaseDescription;
        private readonly string _tagName;

        public CreateTagRequest(uint projectId, string tagName, string refName, string message = null, string releaseDescription = null)
        {
            _projectId = projectId;
            _tagName = tagName;
            _refName = refName;
            _message = message;
            _releaseDescription = releaseDescription;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.POST);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameter("tag_name", _tagName);
            result.AddParameter("ref", _refName);
            result.AddParameterIfNotNull("message", _message);
            result.AddParameterIfNotNull("release_description", _releaseDescription);
            return result;
        }
    }
}