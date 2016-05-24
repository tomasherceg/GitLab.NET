using RestSharp;
using RestSharp.Authenticators;
using System;

namespace GitLab.NET.Factories
{
    public class RestClientFactory : IRestClientFactory
    {
        public IRestClient Create(Uri baseUri, IAuthenticator authenticator = null)
        {
            if (baseUri == null)
                throw new ArgumentNullException(nameof(baseUri));

            var result = new RestClient(baseUri) {Authenticator = authenticator};

            return result;
        }
    }
}
