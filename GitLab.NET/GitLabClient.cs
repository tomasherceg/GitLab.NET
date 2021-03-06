﻿using System;
using GitLab.NET.Abstractions;
using GitLab.NET.Authenticators;
using GitLab.NET.Repositories;

namespace GitLab.NET
{
    /// <summary> A wrapper around the GitLab API. </summary>
    public class GitLabClient
    {
        private const string ApiPath = "/api/v4";

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

        /// <summary> Provides a wrapper around the GitLab branches API. </summary>
        public BranchRepository Branches { get; }

        /// <summary> Provides a wrapper around the GitLab builds API. </summary>
        public BuildRepository Builds { get; }

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

        /// <summary> Provides a wrapper around the GitLab settings API. </summary>
        public GitLabSettingsRepository GitLabSettings { get; }

        /// <summary> Provides a wrapper around the GitLab issues API. </summary>
        public IssueRepository Issues { get; }

        /// <summary> Provides a wrapper around the GitLab keys API. </summary>
        public KeyRepository Keys { get; }

        /// <summary> Provides a wrapper around the GitLab labels API. </summary>
        public LabelRepository Labels { get; }

        /// <summary> Provides a wrapper around the GitLab license templates API. </summary>
        public LicenseRepository Licenses { get; }

        /// <summary> Provides a wrapper around the GitLab merge requests API. </summary>
        public MergeRequestRepository MergeRequests { get; }

        /// <summary> Provides a wrapper around the GitLab milestones API. </summary>
        public MilestoneRepository Milestones { get; }

        /// <summary> Provides a wrapper around the GitLab namespaces API. </summary>
        public NamespaceRepository Namespaces { get; }

        /// <summary> Provides a wrapper around the GitLab project snippets API. </summary>
        public ProjectSnippetRepository ProjectSnippets { get; }

        /// <summary> Provides a wrapper around the GitLab repositories API. </summary>
        public RepositoryRepository Repositories { get; }

        /// <summary> Provides a wrapper around the GitLab runners API. </summary>
        public RunnerRepository Runners { get; }

        /// <summary> Provides a wrapper around the GitLab sessions API. </summary>
        public SessionRepository Session { get; }

        /// <summary> Provides a wrapper around the GitLab system hooks API. </summary>
        public SystemHookRepository SystemHooks { get; }

        /// <summary> Provides a wrapper around the GitLab tags API. </summary>
        public TagRepository Tags { get; }

        /// <summary> Provides a wrapper around the GitLab users API. </summary>
        public UserRepository Users { get; }

        /// <summary> Provides a wrapper around the GitLab projects API. </summary>
        public ProjectRepository Projects { get; }

        /// <summary> Provides a wrapper around the GitLab project members API. </summary>
        public ProjectMemberRepository ProjectMembers { get; }

        /// <summary> Provides a wrapper around the GitLab group members API. </summary>
        public GroupMemberRepository GroupMembers { get; }

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

            Branches = new BranchRepository(requestFactory);
            Builds = new BuildRepository(requestFactory);
            BuildTriggers = new BuildTriggerRepository(requestFactory);
            BuildVariables = new BuildVariableRepository(requestFactory);
            Commits = new CommitRepository(requestFactory);
            DeployKeys = new DeployKeyRepository(requestFactory);
            Emails = new EmailRepository(requestFactory);
            Files = new FileRepository(requestFactory);
            GitLabLicense = new GitLabLicenseRepository(requestFactory);
            GitLabSettings = new GitLabSettingsRepository(requestFactory);
            Issues = new IssueRepository(requestFactory);
            Keys = new KeyRepository(requestFactory);
            Labels = new LabelRepository(requestFactory);
            Licenses = new LicenseRepository(requestFactory);
            MergeRequests = new MergeRequestRepository(requestFactory);
            Milestones = new MilestoneRepository(requestFactory);
            Namespaces = new NamespaceRepository(requestFactory);
            ProjectSnippets = new ProjectSnippetRepository(requestFactory);
            Repositories = new RepositoryRepository(requestFactory);
            Runners = new RunnerRepository(requestFactory);
            Session = new SessionRepository(requestFactory);
            SystemHooks = new SystemHookRepository(requestFactory);
            Tags = new TagRepository(requestFactory);
            Users = new UserRepository(requestFactory);
            Projects = new ProjectRepository(requestFactory);
            ProjectMembers = new ProjectMemberRepository(requestFactory);
            GroupMembers = new GroupMemberRepository(requestFactory);
        }
    }
}