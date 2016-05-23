using RestSharp;

namespace GitLab.NET.RequestHelpers
{
    public class CreateSessionRequest : IRequestHelper
    {
        private const string resource = "session";

        public string User { get; set; }
        public string Password { get; set; }

        public CreateSessionRequest() { }

        public CreateSessionRequest(string user, string password)
        {
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
