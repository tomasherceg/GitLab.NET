using GitLab.NET.Factories;
using GitLab.NET.RestHelpers;
using System;
using System.Diagnostics.CodeAnalysis;
using RestSharp.Authenticators;

namespace GitLab.NET
{
    public abstract class GitLabBase
    {
        private const string ApiPath = "/api/v3";
        
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
        public IRestClientFactory RestClientFactory { get; set; } = new RestClientFactory();
        
        protected readonly RestExecutor RestExecutor;

        protected GitLabBase(string privateToken, Uri hostUri)
        {
            if (privateToken == null)
                throw new ArgumentNullException(nameof(privateToken));

            if (string.IsNullOrWhiteSpace(privateToken))
                throw new ArgumentException("Parameter must not be empty or white space.", nameof(privateToken));

            if (hostUri == null)
                throw new ArgumentNullException(nameof(hostUri));

            var baseUri = new Uri(hostUri, ApiPath);
            var authenticator = new PrivateTokenAuthenticator(privateToken);
            
            RestExecutor = new RestExecutor(RestClientFactory, baseUri, authenticator);
        }
    }
}
