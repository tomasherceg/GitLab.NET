using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetDeployKeysRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/keys";

        private readonly uint _projectId;

        public GetDeployKeysRequest(uint projectId)
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