using System;
using JetBrains.Annotations;
using RestSharp;
using RestSharp.Authenticators;

namespace GitLab.NET
{
    public class RestClientFactory : IRestClientFactory
    {
        public IRestClient Create(Uri baseUri, IAuthenticator authenticator = null)
        {
            var result = new RestClient(baseUri)
            {
                Authenticator = authenticator
            };

            return result;
        }
    }
}