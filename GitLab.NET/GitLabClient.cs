using System;
using GitLab.NET.Abstractions;
using GitLab.NET.Authenticators;
using GitLab.NET.Repositories;

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

        /// <summary> Provides a wrapper around the GitLab commits API. </summary>
        public CommitRepository Commits { get; }

        /// <summary> Provides a wrapper around the GitLab deploy keys API. </summary>
        public DeployKeyRepository DeployKeys { get; }

        /// <summary> Provides a wrapper around the GitLab emails API. </summary>
        public EmailRepository Emails { get; }

        /// <summary> Provides a wrapper around the GitLab files API. </summary>
        public FileRepository Files { get; }

        /// <summary> Provides a wrapper around the GitLab license API. </summary>
        public GitLabLicenseRepository GitLabLicense { get; }

        /// <summary> Provides a wrapper around the GitLab keys API. </summary>
        public KeyRepository Keys { get; }

        /// <summary> Provides a wrapper around the GitLab labels API. </summary>
        public LabelRepository Labels { get; }

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

        /// <summary> Provides a wrapper around the GitLab tags API. </summary>
        public TagRepository Tags { get; }

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
            _authenticator = new PrivateTokenAuthenticator(privateToken);
            var clientFactory = new ClientFactory(baseUri, _authenticator);
            var requestFactory = new RequestFactory(clientFactory);

            BuildTriggers = new BuildTriggerRepository(requestFactory);
            BuildVariables = new BuildVariableRepository(requestFactory);
            Commits = new CommitRepository(requestFactory);
            DeployKeys = new DeployKeyRepository(requestFactory);
            Emails = new EmailRepository(requestFactory);
            Files = new FileRepository(requestFactory);
            GitLabLicense = new GitLabLicenseRepository(requestFactory);
            Keys = new KeyRepository(requestFactory);
            Labels = new LabelRepository(requestFactory);
            Licenses = new LicenseRepository(requestFactory);
            Namespaces = new NamespaceRepository(requestFactory);
            ProjectSnippets = new ProjectSnippetRepository(requestFactory);
            Repositories = new RepositoryRepository(requestFactory);
            Session = new SessionRepository(requestFactory);
            SystemHooks = new SystemHookRepository(requestFactory);
            Tags = new TagRepository(requestFactory);
            Users = new UserRepository(requestFactory);
        }
    }
}