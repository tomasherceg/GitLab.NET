using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class CreateSessionRequest : IRequestModel
    {
        public const string Resource = "session";

        private readonly string _password;
        private readonly string _user;

        public CreateSessionRequest(string user, string password)
        {
            _user = user;
            _password = password;
        }

        public IRestRequest GetRequest()
        {
            var request = new RestRequest(Resource, Method.POST);

            request.AddParameter("login", _user);
            request.AddParameter("password", _password);

            return request;
        }
    }
}