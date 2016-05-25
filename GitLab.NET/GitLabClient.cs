using System;

namespace GitLab.NET
{
    public class GitLabClient
    {
        private const string ApiPath = "/api/v3";

        // ReSharper disable MemberCanBePrivate.Global
        // ReSharper disable UnusedAutoPropertyAccessor.Global
        public UserRepository Users { get; }
        // ReSharper restore UnusedAutoPropertyAccessor.Global
        // ReSharper restore MemberCanBePrivate.Global

        public GitLabClient(string privateToken, Uri hostUri)
        {
            if (privateToken == null)
                throw new ArgumentNullException(nameof(privateToken));

            if (string.IsNullOrWhiteSpace(privateToken))
                throw new ArgumentException("Parameter must not be empty or white space.", nameof(privateToken));

            if (hostUri == null)
                throw new ArgumentNullException(nameof(hostUri));

            var baseUri = new Uri(hostUri, ApiPath);
            var authenticator = new PrivateTokenAuthenticator(privateToken);
            var restExecutor = new RestExecutor(new RestClientFactory(), baseUri, authenticator);

            Users = new UserRepository(restExecutor);
        }
    }
}