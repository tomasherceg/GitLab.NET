using GitLabAPI.NET.Factories;
using GitLabAPI.NET.Models;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace GitLabAPI.NET
{
    /// <summary>
    /// Retrieves a private token for a given username/password combination.
    /// </summary>
    public class GitLabAuthenticator
    {
        public IRestClientFactory RestClientFactory { get; set; } = new RestClientFactory();
        public IRestRequestFactory RestRequestFactory { get; set; } = new RestRequestFactory();

        private Uri baseUri = new Uri("https://gitlab.com" + apiPath);
        private const string apiPath = "/api/v3";

        public GitLabAuthenticator() { }

        public GitLabAuthenticator(Uri hostUri)
        {
            baseUri = new Uri(hostUri, apiPath);
        }

        /// <summary>
        /// Retrieves a private token for a user.
        /// </summary>
        /// <param name="user">The username or email address for the user.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>The user's private token. Null if the login failed.</returns>
        public async Task<string> GetPrivateToken(string user, string password, Uri hostUri)
        {
            var client = RestClientFactory.Create();
            client.BaseUrl = baseUri;

            var request = RestRequestFactory.Create();
            request.Method = Method.POST;
            request.AddParameter("login", user);
            request.AddParameter("password", password);

            var response = await client.ExecuteTaskAsync<User>(request);

            //if (response.StatusCode == System.Net.HttpStatusCode.Created)

            return response.Data.PrivateToken;
        }
    }
}
