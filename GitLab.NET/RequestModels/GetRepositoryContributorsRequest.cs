using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetRepositoryContributorsRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/repository/contributors";

        private readonly uint _projectId;

        public GetRepositoryContributorsRequest(uint projectId)
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