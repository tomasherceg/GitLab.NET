using GitLab.NET.Factories;
using GitLab.NET.RestHelpers;
using GitLab.NET.Models;
using GitLab.NET.RequestHelpers;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitLab.NET
{
    public abstract class GitLabBase
    {
        public IRestClientFactory RestClientFactory { get; set; } = new RestClientFactory();

        private const string apiPath = "/api/v3";
        
        private RestExecutor restExecutor;

        public GitLabBase(string privateToken, Uri hostUri)
        {
            if (string.IsNullOrWhiteSpace(privateToken))
                throw new ArgumentNullException(nameof(privateToken));

            if (hostUri == null)
                throw new ArgumentNullException(nameof(hostUri));

            var baseUri = new Uri(hostUri, apiPath);
            var authenticator = new PrivateTokenAuthenticator(privateToken);
            
            restExecutor = new RestExecutor(RestClientFactory, baseUri, authenticator);
        }
    }
}
