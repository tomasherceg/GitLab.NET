using System;
using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetCommitsRequest : IRequestModel
    {
        public const string Resource = "projects/{projectId}/repository/commits";

        private readonly uint _projectId;
        private readonly string _refName;
        private readonly DateTime? _since;
        private readonly DateTime? _until;

        public GetCommitsRequest(uint projectId, string refName = null, DateTime? since = null, DateTime? until = null)
        {
            _projectId = projectId;
            _refName = refName;
            _since = since;
            _until = until;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.GET);
            result.AddParameter("projectId", _projectId, ParameterType.UrlSegment);
            result.AddParameterIfNotNull("ref_name", _refName);
            result.AddParameterIfNotNull("since", _since);
            result.AddParameterIfNotNull("until", _until);
            return result;
        }
    }
}