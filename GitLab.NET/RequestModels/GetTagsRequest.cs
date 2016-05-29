using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetTagsRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/repository/tags";

        private readonly uint _projectId;

        public GetTagsRequest(uint projectId)
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