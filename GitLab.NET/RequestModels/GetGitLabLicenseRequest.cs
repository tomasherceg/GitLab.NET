using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class GetGitLabLicenseRequest : IRequestModel
    {
        public const string Resource = "license";

        public IRestRequest GetRequest()
        {
            var result = new RestRequest(Resource, Method.GET);
            return result;
        }
    }
}