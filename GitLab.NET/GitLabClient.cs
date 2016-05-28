using System;

namespace GitLab.NET
{
    /// <summary> A wrapper around the GitLab API. </summary>
    public class GitLabClient
    {
        private const string ApiPath = "/api/v3";

        private readonly IPrivateTokenAuthenticator _authenticator;

        /// <summary> The user's private token. </summary>
        public string PrivateToken
        {
            get { return _authenticator.PrivateToken; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                _authenticator.PrivateToken = value;
            }
        }

        /// <summary> Provides a wrapper around the GitLab emails API. </summary>
        public EmailRepository Emails { get; }

        /// <summary> Provides a wrapper around the GitLab keys API. </summary>
        public KeyRepository Keys { get; }

        /// <summary> Provides a wrapper around the GitLab license API. </summary>
        public GitLabLicenseRepository GitLabLicense { get; }

        /// <summary> Provides a wrapper around the GitLab project snippets API. </summary>
        public ProjectSnippetRepository ProjectSnippets { get; }

        /// <summary> Provides a wrapper around the GitLab sessions API. </summary>
        public SessionRepository Session { get; }

        /// <summary> Provides a wrapper around the GitLab users API. </summary>
        public UserRepository Users { get; }

        /// <summary> Creates a new <see cref="GitLabClient" /> instance. </summary>
        /// <param name="hostUri"> The GitLab server to connect to. </param>
        /// <param name="privateToken"> The private token to use when making requests to the GitLab API. </param>
        public GitLabClient(Uri hostUri, string privateToken = null)
        {
            if (hostUri == null)
                throw new ArgumentNullException(nameof(hostUri));

            var baseUri = new Uri(hostUri, ApiPath);
            _authenticator = new PrivateTokenAuthenticator
            {
                PrivateToken = privateToken
            };
            var restExecutor = new RequestExecutor(new RestClientFactory(), baseUri, _authenticator);

            Emails = new EmailRepository(restExecutor);
            GitLabLicense = new GitLabLicenseRepository(restExecutor);
            Keys = new KeyRepository(restExecutor);
            ProjectSnippets = new ProjectSnippetRepository(restExecutor);
            Session = new SessionRepository(restExecutor);
            Users = new UserRepository(restExecutor);
        }
    }
}