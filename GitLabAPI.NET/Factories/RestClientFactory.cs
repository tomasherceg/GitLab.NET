using RestSharp;
using RestSharp.Authenticators;
using System;

namespace GitLabAPI.NET.Factories
{
    public class RestClientFactory : IRestClientFactory
    {
        public IRestClient Create(Uri baseUri, IAuthenticator authenticator = null)
        {
            if (baseUri == null)
                throw new ArgumentNullException(nameof(baseUri));

            var result = Create(baseUri);
            result.Authenticator = authenticator;

            return result;
        }
    }
}
