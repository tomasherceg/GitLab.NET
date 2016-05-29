using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class CreateLabelRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/labels";
        private readonly string _color;
        private readonly string _description;
        private readonly string _name;

        private readonly uint _projectId;

        public CreateLabelRequest(uint projectId, string name, string color, string description = null)
        {
            _projectId = projectId;
            _name = name;
            _color = color;
            _description = description;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.POST);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameter("name", _name);
            result.AddParameter("color", _color);
            result.AddParameterIfNotNull("description", _description);
            return result;
        }
    }
}