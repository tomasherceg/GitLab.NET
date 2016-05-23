using RestSharp;
using RestSharp.Authenticators;

namespace GitLab.NET
{
    public class PrivateTokenAuthenticator : IAuthenticator
    {
        private readonly string privateToken;

        public PrivateTokenAuthenticator(string privateToken)
        {
            this.privateToken = privateToken;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            request.AddParameter("PRIVATE-TOKEN", privateToken, ParameterType.HttpHeader);
        }
    }
}
