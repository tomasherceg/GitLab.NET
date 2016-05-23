using RestSharp;

namespace GitLab.NET.RequestHelpers
{
    public class GetUsersRequest : IRequestHelper
    {
        private const string resource = "users";

        public RestRequest GetRequest()
        {
            var request = new RestRequest(resource, Method.GET);

            return request;
        }
    }
}
