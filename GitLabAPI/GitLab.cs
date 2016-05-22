using GitLabAPI.Factories;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace GitLabAPI
{
    public class GitLab
    {
        public IRestClientFactory RestClientFactory { get; set; } = new RestClientFactory();

        private Uri baseUri = new Uri("https://gitlab.com" + apiPath);
        private const string apiPath = "/api/v3";
        private string privateToken;

        public GitLab(string privateToken)
        {
            if (string.IsNullOrEmpty(privateToken))
                throw new ArgumentNullException(nameof(privateToken));

            this.privateToken = privateToken;
        }

        public GitLab(string privateToken, Uri hostUri) : this(privateToken)
        {
            hostUri = new Uri(hostUri, apiPath);
        }

        /// <summary>
        /// Retrieves a private token for a user.
        /// </summary>
        /// <param name="user">The username or email address for the user.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>The user's private token. Null if the login failed.</returns>
        public static async Task<string> GetPrivateToken(string user, string password, Uri hostUri)
        {

        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            var client = RestClientFactory.Create();
            client.BaseUrl = baseUri;

            // Add the private token to every request
            request.AddParameter("PRIVATE-TOKEN", privateToken, ParameterType.HttpHeader);

            var response = client.Execute<T>(request);

            return response.Data;
        }

        public async Task<T> ExecuteAsync<T>(RestRequest request) where T : new()
        {
            var client = RestClientFactory.Create();
            client.BaseUrl = baseUri;

            // Add the private token to every request
            request.AddParameter("PRIVATE-TOKEN", privateToken, ParameterType.HttpHeader);

            var response = await client.ExecuteTaskAsync<T>(request);

            return response.Data;
        }
    }
}
