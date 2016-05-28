using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetBuildTriggersRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/triggers";

        private readonly uint _projectId;

        public GetBuildTriggersRequest(uint projectId)
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