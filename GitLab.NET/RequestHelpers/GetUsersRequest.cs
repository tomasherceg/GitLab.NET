using GitLab.NET.RestSharpExtensions;
using RestSharp;

namespace GitLab.NET.RequestHelpers
{
    public class GetUsersRequest : IRequestHelper
    {
        private const string resource = "users";

        public string Search { get; set; }

        public GetUsersRequest() { }

        public RestRequest GetRequest()
        {
            var request = new RestRequest(resource, Method.GET);

            request.AddParameterIfNotNull("search", Search);

            return request;
        }
    }
}
