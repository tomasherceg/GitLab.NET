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

        /// <summary> Provides a wrapper around the GitLab build triggers API. </summary>
        public BuildTriggerRepository BuildTriggers { get; }

        /// <summary> Provides a wrapper around the GitLab build variables API. </summary>
        public BuildVariableRepository BuildVariables { get; }

        /// <summary> Provides a wrapper around the GitLab deploy keys API. </summary>
        public DeployKeyRepository DeployKeys { get; }

        /// <summary> Provides a wrapper around the GitLab emails API. </summary>
        public EmailRepository Emails { get; }

        /// <summary> Provides a wrapper around the GitLab license API. </summary>
        public GitLabLicenseRepository GitLabLicense { get; }

        /// <summary> Provides a wrapper around the GitLab keys API. </summary>
        public KeyRepository Keys { get; }

        /// <summary> Provides a wrapper around the GitLab license template API. </summary>
        public LicenseRepository Licenses { get; }

        /// <summary> Provides a wrapper around the GitLab namespace API. </summary>
        public NamespaceRepository Namespaces { get; }

        /// <summary> Provides a wrapper around the GitLab project snippets API. </summary>
        public ProjectSnippetRepository ProjectSnippets { get; }

        /// <summary> Provides a wrapper around the GitLab repository API. </summary>
        public RepositoryRepository Repositories { get; }

        /// <summary> Provides a wrapper around the GitLab sessions API. </summary>
        public SessionRepository Session { get; }

        /// <summary> Provides a wrapper around the GitLab system hooks API. </summary>
        public SystemHookRepository SystemHooks { get; }

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

            BuildTriggers = new BuildTriggerRepository(restExecutor);
            BuildVariables = new BuildVariableRepository(restExecutor);
            DeployKeys = new DeployKeyRepository(restExecutor);
            Emails = new EmailRepository(restExecutor);
            GitLabLicense = new GitLabLicenseRepository(restExecutor);
            Keys = new KeyRepository(restExecutor);
            Licenses = new LicenseRepository(restExecutor);
            Namespaces = new NamespaceRepository(restExecutor);
            ProjectSnippets = new ProjectSnippetRepository(restExecutor);
            Repositories = new RepositoryRepository(restExecutor);
            Session = new SessionRepository(restExecutor);
            SystemHooks = new SystemHookRepository(restExecutor);
            Users = new UserRepository(restExecutor);
        }
    }
}