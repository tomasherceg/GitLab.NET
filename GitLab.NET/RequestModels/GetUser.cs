using RestSharp;
using System;

namespace GitLab.NET.RequestModels
{
    public class GetUser : IRequestModel
    {
        public const string ByIdResource = "users/{id}";
        public const string ByUsernameResource = "users";

        public int? Id { get; private set; }
        public string Username { get; private set; }

        public GetUser(int id)
        {
            Id = id;
        }

        public GetUser(string username)
        {
            if (username == null)
                throw new ArgumentNullException(nameof(username));

            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Parameter must not be empty or white space.", nameof(username));

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
                request.AddParameter("id", Id, ParameterType.UrlSegment);
                return request;
            }
        }
    }
}
