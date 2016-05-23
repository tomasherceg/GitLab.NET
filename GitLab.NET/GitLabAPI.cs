﻿using System;

namespace GitLab.NET
{
    /// <summary>
    /// GitLab.NET base class. This class is a base implementation of the GitLab.NET library.
    /// </summary>
    public class GitLabAPI
    {
        public GitLabUsers Users { get; private set; }

        public GitLabAPI(string privateToken, Uri hostUri)
        {
            if (string.IsNullOrWhiteSpace(privateToken))
                throw new ArgumentNullException(nameof(privateToken));

            if (hostUri == null)
                throw new ArgumentNullException(nameof(hostUri));

            Users = new GitLabUsers(privateToken, hostUri);
        }
    }
}