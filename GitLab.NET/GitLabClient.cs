// ReSharper disable MemberCanBePrivate.Global
using System;
using JetBrains.Annotations;

namespace GitLab.NET
{
    /// <summary>
    /// GitLab.NET base class. This class is a base implementation of the GitLab.NET library.
    /// </summary>
    public class GitLabClient
    {
        public GitLabUsers Users { [UsedImplicitly] get; private set; }

        public GitLabClient(string privateToken, Uri hostUri)
        {
            if (privateToken == null)
                throw new ArgumentNullException(nameof(privateToken));

            if (string.IsNullOrWhiteSpace(privateToken))
                throw new ArgumentException("Parameter must not be empty or white space.", nameof(privateToken));

            if (hostUri == null)
                throw new ArgumentNullException(nameof(hostUri));

            Users = new GitLabUsers(privateToken, hostUri);
        }
    }
}
