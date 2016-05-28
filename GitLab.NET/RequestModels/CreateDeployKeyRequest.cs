using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class CreateDeployKeyRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/keys";
        private readonly string _key;

        private readonly uint _projectId;
        private readonly string _title;

        public CreateDeployKeyRequest(uint projectId, string title, string key)
        {
            _projectId = projectId;
            _title = title;
            _key = key;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.POST);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameter("title", _title);
            result.AddParameter("key", _key);
            return result;
        }
    }
}