using System;
using GitLab.NET.Authenticators;
using RestSharp;

namespace GitLab.NET.Abstractions
{
    internal class ClientFactory : IClientFactory
    {
        private readonly IPrivateTokenAuthenticator _authenticator;
        private readonly Uri _baseUri;

        public ClientFactory(Uri baseUri, IPrivateTokenAuthenticator authenticator)
        {
            _baseUri = baseUri;
            _authenticator = authenticator;
        }

        public IRestClient Create(bool authenticate = true)
        {
            var client = new RestClient(_baseUri);

            if (authenticate)
                client.Authenticator = _authenticator;

            return client;
        }
    }
}