using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetRepositoryTreeRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/repository/tree";
        private readonly string _path;

        private readonly uint _projectId;
        private readonly string _refName;

        public GetRepositoryTreeRequest(uint projectId, string path = null, string refName = null)
        {
            _projectId = projectId;
            _path = path;
            _refName = refName;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.GET);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameterIfNotNull("path", _path);
            result.AddParameterIfNotNull("ref_name", _refName);
            return result;
        }
    }
}