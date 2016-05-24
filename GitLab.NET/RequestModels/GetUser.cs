using RestSharp;
using System;

namespace GitLab.NET.RequestModels
{
    public class GetUser : IRequestModel
    {
        public const string ByIdResource = "users/{id}";
        public const string ByUsernameResource = "users";

        private readonly int? _id;
        private readonly string _username;

        public GetUser(int id)
        {
            _id = id;
        }

        public GetUser(string username)
        {
            if (username == null)
                throw new ArgumentNullException(nameof(username));

            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Parameter must not be empty or white space.", nameof(username));

            _username = username;
        }

        public RestRequest GetRequest()
        {
            if (_username != null)
            {
                var request = new RestRequest(ByUsernameResource, Method.GET);
                request.AddParameter("username", _username);
                return request;
            }
            else
            {
                var request = new RestRequest(ByIdResource, Method.GET);
                request.AddParameter("id", _id, ParameterType.UrlSegment);
                return request;
            }
        }
    }
}
