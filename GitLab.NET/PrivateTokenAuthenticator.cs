using RestSharp;
using RestSharp.Authenticators;
using System;

namespace GitLab.NET
{
    public class PrivateTokenAuthenticator : IAuthenticator
    {
        private readonly string privateToken;

        public PrivateTokenAuthenticator(string privateToken)
        {
            if (privateToken == null)
                throw new ArgumentNullException(nameof(privateToken));

            if (string.IsNullOrWhiteSpace(privateToken))
                throw new ArgumentException("Parameter must not be empty or white space.", nameof(privateToken));

            this.privateToken = privateToken;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            request.AddParameter("PRIVATE-TOKEN", privateToken, ParameterType.HttpHeader);
        }
    }
}
