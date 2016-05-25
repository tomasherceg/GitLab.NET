using JetBrains.Annotations;
using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class CreateSessionRequest : IRequestModel
    {
        private const string Resource = "session";
        private readonly string _password;

        private readonly string _user;

        public CreateSessionRequest([NotNull] string user, [NotNull] string password)
        {
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