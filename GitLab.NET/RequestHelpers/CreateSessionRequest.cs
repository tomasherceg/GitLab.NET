using System;
using RestSharp;

namespace GitLab.NET.RequestHelpers
{
    public class CreateSessionRequest : IRequestHelper
    {
        public const string resource = "session";

        public string User { get; private set; }
        public string Password { get; private set; }

        public CreateSessionRequest(string user, string password)
        {
            if (string.IsNullOrWhiteSpace(user))
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException(nameof(password));

            User = user;
            Password = password;
        }

        public RestRequest GetRequest()
        {
            var request = new RestRequest(resource, Method.POST);
            request.AddParameter("login", User);
            request.AddParameter("password", Password);
            return request;
        }
    }
}
