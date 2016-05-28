using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class CreateBuildTriggerRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/triggers";

        private readonly uint _projectId;

        public CreateBuildTriggerRequest(uint projectId)
        {
            _projectId = projectId;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.POST);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            return result;
        }
    }
}