using RestSharp;
using RestSharp.Authenticators;
using System;

namespace GitLabAPI.NET.Factories
{
    public class RestClientFactory : IRestClientFactory
    {
        public IRestClient Create(Uri baseUri)
        {
            return new RestClient(baseUri);
        }

        public IRestClient Create(Uri baseUri, IAuthenticator authenticator)
        {
            var result = Create(baseUri);
            result.Authenticator = authenticator;

            return result;
        }
    }
}
