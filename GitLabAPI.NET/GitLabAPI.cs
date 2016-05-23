using GitLabAPI.NET.Factories;
using GitLabAPI.NET.Helpers;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Threading.Tasks;

namespace GitLabAPI.NET
{
    public class GitLabAPI
    {
        public IRestClientFactory RestClientFactory { get; set; } = new RestClientFactory();

        private const string apiPath = "/api/v3";
        
        private RestExecutor requestExecutor;

        public GitLabAPI(string privateToken, Uri hostUri)
        {
            if (string.IsNullOrEmpty(privateToken))
                throw new ArgumentNullException(nameof(privateToken));

            if (hostUri == null)
                throw new ArgumentNullException(nameof(hostUri));

            var baseUri = new Uri(hostUri, apiPath);
            var authenticator = new PrivateTokenAuthenticator(privateToken);
            
            requestExecutor = new RestExecutor(RestClientFactory, baseUri, authenticator);
        }
    }
}
