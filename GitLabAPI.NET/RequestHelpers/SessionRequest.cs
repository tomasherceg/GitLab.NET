using RestSharp;

namespace GitLabAPI.NET.RequestHelpers
{
    public class SessionRequest : IRequestHelper
    {
        private const string _url = "/session";
        public string Url
        {
            get
            {
                return _url;
            }
        }

        public string User { get; set; }
        public string Password { get; set; }

        public SessionRequest() { }

        public SessionRequest(string user, string password)
        {
            User = user;
            Password = password;
        }

        public RestRequest GetRequest()
        {
            var request = new RestRequest(Method.POST);
            request.AddParameter("login", User);
            request.AddParameter("password", Password);
            return request;
        }
    }
}
