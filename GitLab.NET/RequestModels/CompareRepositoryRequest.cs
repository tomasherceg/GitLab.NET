using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class CompareRepositoryRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/repository/compare";

        private readonly string _from;
        private readonly uint _projectId;
        private readonly string _to;

        public CompareRepositoryRequest(uint projectId, string from, string to)
        {
            _projectId = projectId;
            _from = from;
            _to = to;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.GET);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameter("from", _from);
            result.AddParameter("to", _to);
            return result;
        }
    }
}