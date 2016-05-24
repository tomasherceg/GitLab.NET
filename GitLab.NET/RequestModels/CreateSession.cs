using System;
using RestSharp;

namespace GitLab.NET.RequestModels
{
    public class CreateSession : IRequestModel
    {
        public const string resource = "session";

        public string User { get; private set; }
        public string Password { get; private set; }

        public CreateSession(string user, string password)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (string.IsNullOrWhiteSpace(user))
                throw new ArgumentException("Parameter must not be empty or white space.", nameof(user));

            if (password == null)
                throw new ArgumentNullException(nameof(password));

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Parameter must not be empty or white space.", nameof(password));

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
