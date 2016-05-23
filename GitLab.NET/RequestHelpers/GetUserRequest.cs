using RestSharp;

namespace GitLab.NET.RequestHelpers
{
    public class GetUserRequest : IRequestHelper
    {
        public const string byIdResource = "users/{UserId}";
        public const string byUsernameResource = "users";

        public int? Id { get; private set; }
        public string Username { get; private set; }

        public GetUserRequest(int id)
        {
            Id = id;
        }

        public GetUserRequest(string username)
        {
            Username = username;
        }

        public RestRequest GetRequest()
        {
            if (Username != null)
            {
                var request = new RestRequest(byUsernameResource, Method.GET);
                request.AddParameter("username", Username);
                return request;
            }
            else
            {
                var request = new RestRequest(byIdResource, Method.GET);
                request.AddParameter("UserId", Id, ParameterType.UrlSegment);
                return request;
            }
        }
    }
}
