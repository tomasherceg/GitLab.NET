using RestSharp;

namespace GitLabAPI.NET.RequestHelpers
{
    public class UsersRequest : IRequestHelper
    {
        private const string resource = "users";

        public RestRequest GetRequest()
        {
            var request = new RestRequest(resource, Method.GET);

            return request;
        }
    }
}
