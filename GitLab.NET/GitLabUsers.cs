using GitLab.NET.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitLab.NET
{
    public class GitLabUsers : GitLabAPI
    {
        public GitLabUsers(string privateToken, Uri hostUri) : base(privateToken, hostUri) { }

        /// <summary>
        /// Gets a user by their user id.
        /// </summary>
        /// <param name="id">The user's id.</param>
        /// <returns>The user if one was found, null if no user was found.</returns>
        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a user by their username.
        /// </summary>
        /// <param name="username">The user's username.</param>
        /// <returns>The user if one was found, null if no user was found.</returns>
        public User Get(string username)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Searches for a user by their email address or name.
        /// </summary>
        /// <param name="searchQuery">The user's name or email address.</param>
        /// <returns>A list of users matching the provided name or email address.</returns>
        public List<User> Search(string searchQuery)
        {
            throw new NotImplementedException();
        }
    }
}
