using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLab.NET
{
    public class GitLabAPI
    {
        public GitLabUsers Users { get; private set; }

        public GitLabAPI(string privateToken, Uri hostUri)
        {
            if (string.IsNullOrEmpty(privateToken))
                throw new ArgumentNullException(nameof(privateToken));

            if (hostUri == null)
                throw new ArgumentNullException(nameof(hostUri));

            Users = new GitLabUsers(privateToken, hostUri);
        }
    }
}
