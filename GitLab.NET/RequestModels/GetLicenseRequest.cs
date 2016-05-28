using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetLicenseRequest : IRequestModel
    {
        public const string Resource = "licenses/{key}";

        private readonly string _key;
        private readonly string _project;
        private readonly string _fullName;

        public GetLicenseRequest(string key, string project = null, string fullName = null)
        {
            _key = key;
            _project = project;
            _fullName = fullName;
        }

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.GET);
            result.AddParameter("key", _key, ParameterType.UrlSegment);
            result.AddParameterIfNotNull("project", _project);
            result.AddParameterIfNotNull("fullname", _fullName);
            return result;
        }
    }
}