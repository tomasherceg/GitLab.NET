using RestSharp;

namespace GitLab.NET.RequestModels
{
    internal class CreateEmailRequest : IRequestModel
    {
        public const string ForCurrentUserResource = "user/emails";
        public const string ForSpecifiedUserResource = "users/{id}/emails";

        private readonly uint? _userId;
        private readonly string _email;

        public CreateEmailRequest(string email)
        {
            _email = email;
        }

        public CreateEmailRequest(uint userId, string email)
        {
            _userId = userId;
            _email = email;
        }

        public IRestRequest GetRequest()
        {
            if (_userId != null)
            {
                var request = new RestRequest(ForSpecifiedUserResource, Method.POST);
                request.AddParameter("id", _userId, ParameterType.UrlSegment);
                request.AddParameter("email", _email);
                return request;
            }
            else
            {
                var request = new RestRequest(ForCurrentUserResource, Method.POST);
                request.AddParameter("email", _email);
                return request;
            }
        }
    }
}