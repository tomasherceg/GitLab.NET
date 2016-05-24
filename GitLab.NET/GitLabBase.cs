using GitLab.NET.Factories;
using GitLab.NET.RestHelpers;
using System;

namespace GitLab.NET
{
    public abstract class GitLabBase
    {
        private const string apiPath = "/api/v3";

        public IRestClientFactory RestClientFactory { get; set; } = new RestClientFactory();
        
        protected RestExecutor restExecutor;

        public GitLabBase(string privateToken, Uri hostUri)
        {
            if (privateToken == null)
                throw new ArgumentNullException(nameof(privateToken));

            if (string.IsNullOrWhiteSpace(privateToken))
                throw new ArgumentException("Parameter must not be empty or white space.", nameof(privateToken));

            if (hostUri == null)
                throw new ArgumentNullException(nameof(hostUri));

            var baseUri = new Uri(hostUri, apiPath);
            var authenticator = new PrivateTokenAuthenticator(privateToken);
            
            restExecutor = new RestExecutor(RestClientFactory, baseUri, authenticator);
        }
    }
}
