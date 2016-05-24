using GitLab.NET.Factories;
using GitLab.NET.RestHelpers;
using GitLab.NET.RequestModels;
using System;
using System.Threading.Tasks;
using GitLab.NET.ResponseModels;
using JetBrains.Annotations;

namespace GitLab.NET
{
    /// <summary>
    /// Retrieves a private token for a given username/password combination.
    /// </summary>
    public class UserAuthenticator
    {
        [UsedImplicitly]
        public IRestClientFactory RestClientFactory { get; set; } = new RestClientFactory();
        
        private const string ApiPath = "/api/v3";

        private readonly RestExecutor _restExecutor;

        /// <summary>
        /// Creates a new instance of UserAuthenticator.
        /// </summary>
        /// <param name="hostUri">The url for the GitLab server without /api/v3.</param>
        public UserAuthenticator(Uri hostUri)
        {
            if (hostUri == null)
                throw new ArgumentNullException(nameof(hostUri));

            var baseUri = new Uri(hostUri, ApiPath);

            _restExecutor = new RestExecutor(RestClientFactory, baseUri);
        }

        /// <summary>
        /// Synchronously retrieves a private token for a user.
        /// </summary>
        /// <param name="user">The username or email address for the user.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>The user's private token. Null if the username/password was incorrect.</returns>
        [UsedImplicitly]
        public string GetPrivateToken(string user, string password)
        {
            var request = new CreateSession(user, password);

            var response = _restExecutor.Execute<User>(request);

            return response.Data.PrivateToken;
        }

        /// <summary>
        /// Asynchronously retrieves a private token for a user.
        /// </summary>
        /// <param name="user">The username or email address for the user.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>The user's private token. Null if the username/password was incorrect.</returns>
        [UsedImplicitly]
        public async Task<string> GetPrivateTokenAsync(string user, string password)
        {
            var request = new CreateSession(user, password);

            var response = await _restExecutor.ExecuteAsync<User>(request);

            return response.Data.PrivateToken;
        }
    }
}
