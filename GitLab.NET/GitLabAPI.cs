using GitLab.NET.Factories;
using GitLab.NET.Helpers;
using GitLab.NET.Models;
using GitLab.NET.RequestHelpers;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitLab.NET
{
    public class GitLabAPI
    {
        public IRestClientFactory RestClientFactory { get; set; } = new RestClientFactory();

        private const string apiPath = "/api/v3";
        
        private RestExecutor restExecutor;

        public GitLabAPI(string privateToken, Uri hostUri)
        {
            if (string.IsNullOrEmpty(privateToken))
                throw new ArgumentNullException(nameof(privateToken));

            if (hostUri == null)
                throw new ArgumentNullException(nameof(hostUri));

            var baseUri = new Uri(hostUri, apiPath);
            var authenticator = new PrivateTokenAuthenticator(privateToken);
            
            restExecutor = new RestExecutor(RestClientFactory, baseUri, authenticator);
        }

        public IRestResponse<List<User>> Test()
        {
            var request = new UsersRequest();

            var response = restExecutor.Execute<List<User>>(request);

            return response;
        }

        public List<User> GetUsers()
        {
            var request = new UsersRequest();

            var response = restExecutor.Execute<List<User>>(request);

            return response.Data;
        }
    }
}
