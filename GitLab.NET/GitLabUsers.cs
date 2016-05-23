using GitLab.NET.Models;
using GitLab.NET.RequestHelpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitLab.NET
{
    public class GitLabUsers : GitLabBase
    {
        public GitLabUsers(string privateToken, Uri hostUri) : base(privateToken, hostUri) { }

        /// <summary>
        /// Gets a user by the user's id.
        /// </summary>
        /// <param name="id">The user's id.</param>
        /// <returns>The user if one was found, null if no user was found.</returns>
        public User Get(int id)
        {
            var request = new GetUserRequest(id);

            var result = restExecutor.Execute<User>(request);

            return result.Data;
        }

        /// <summary>
        /// Gets a user by username.
        /// </summary>
        /// <param name="username">The user's username.</param>
        /// <returns>The user if one was found, null if no user was found.</returns>
        public User Get(string username)
        {
            var request = new GetUserRequest(username);

            var result = restExecutor.Execute<User>(request);

            return result.Data;
        }

        /// <summary>
        /// Searches for a user by email address or name.
        /// </summary>
        /// <param name="searchQuery">The user's name or email address.</param>
        /// <returns>A list of users matching the provided name or email address.</returns>
        public List<User> Search(string searchQuery)
        {

        }
    }
}
