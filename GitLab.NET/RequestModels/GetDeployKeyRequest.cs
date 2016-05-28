using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetDeployKeyRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/keys/{keyId}";
        private readonly uint _keyId;

        private readonly uint _projectId;

        public GetDeployKeyRequest(uint projectId, uint keyId)
        {
            _projectId = projectId;
            _keyId = keyId;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.GET);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameter("keyId", _keyId, ParameterType.UrlSegment);
            return result;
        }
    }
}