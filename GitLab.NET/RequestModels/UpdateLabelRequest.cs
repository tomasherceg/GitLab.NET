using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class UpdateLabelRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/labels";

        private readonly string _color;
        private readonly string _description;
        private readonly string _name;
        private readonly string _newName;
        private readonly uint _projectId;

        public UpdateLabelRequest(uint projectId, string name, string newName = null, string color = null, string description = null)
        {
            _projectId = projectId;
            _name = name;
            _newName = newName;
            _color = color;
            _description = description;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.PUT);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameter("name", _name);
            result.AddParameterIfNotNull("new_name", _newName);
            result.AddParameterIfNotNull("color", _color);
            result.AddParameterIfNotNull("description", _description);
            return result;
        }
    }
}