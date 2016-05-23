using GitLab.NET.RestSharpExtensions;
using RestSharp;

namespace GitLab.NET.RequestHelpers
{
    public class GetUsersRequest : IRequestHelper
    {
        public const string resource = "users";

        public string Search { get; private set; }

        public GetUsersRequest() { }

        public GetUsersRequest(string search)
        {
            Search = search;
        }

        public RestRequest GetRequest()
        {
            var request = new RestRequest(resource, Method.GET);

            request.AddParameterIfNotNull("search", Search);

            return request;
        }
    }
}
