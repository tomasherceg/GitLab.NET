using System;
using RestSharp;
using RestSharp.Authenticators;

namespace GitLab.NET
{
    public class PrivateTokenAuthenticator : IAuthenticator
    {
        private readonly string _privateToken;

        public PrivateTokenAuthenticator(string privateToken)
        {
            if (privateToken == null)
                throw new ArgumentNullException(nameof(privateToken));

            if (string.IsNullOrWhiteSpace(privateToken))
                throw new ArgumentException("Parameter must not be empty or white space.", nameof(privateToken));

            _privateToken = privateToken;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            if (request == null)
                throw new ArgumentNullException(nameof(request));

            request.AddParameter("PRIVATE-TOKEN", _privateToken, ParameterType.HttpHeader);
        }
    }
}