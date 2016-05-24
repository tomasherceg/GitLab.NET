using System;
using RestSharp;

namespace GitLab.NET.RequestModels
{
    public class CreateSession : IRequestModel
    {
        private const string Resource = "session";

        private readonly string _user;
        private readonly string _password;

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

            _user = user;
            _password = password;
        }

        public RestRequest GetRequest()
        {
            var request = new RestRequest(Resource, Method.POST);
            request.AddParameter("login", _user);
            request.AddParameter("password", _password);
            return request;
        }
    }
}
