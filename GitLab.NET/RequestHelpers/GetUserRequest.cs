using RestSharp;
using System;

namespace GitLab.NET.RequestHelpers
{
    public class GetUserRequest : IRequestHelper
    {
        public const string ByIdResource = "users/{UserId}";
        public const string ByUsernameResource = "users";

        public int? Id { get; private set; }
        public string Username { get; private set; }

        public GetUserRequest(int id)
        {
            Id = id;
        }

        public GetUserRequest(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentNullException(nameof(username));

            Username = username;
        }

        public RestRequest GetRequest()
        {
            if (Username != null)
            {
                var request = new RestRequest(ByUsernameResource, Method.GET);
                request.AddParameter("username", Username);
                return request;
            }
            else
            {
                var request = new RestRequest(ByIdResource, Method.GET);
                request.AddParameter("UserId", Id, ParameterType.UrlSegment);
                return request;
            }
        }
    }
}
