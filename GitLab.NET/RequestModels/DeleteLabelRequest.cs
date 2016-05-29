using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class DeleteLabelRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/labels";
        private readonly string _name;

        private readonly uint _projectId;

        public DeleteLabelRequest(uint projectId, string name)
        {
            _projectId = projectId;
            _name = name;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.DELETE);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameter("name", _name);
            return result;
        }
    }
}