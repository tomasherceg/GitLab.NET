using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Retrieves a private token for a given username/password combination. </summary>
    public class SessionRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="SessionRepository" /> instance. </summary>
        /// <param name="requestFactory"> An instance of <see cref="IRequestFactory" /> to use for this repository. </param>
        public SessionRepository(IRequestFactory requestFactory) : base(requestFactory) { }

        /// <summary> Asynchronously retrieves a private token for a user. </summary>
        /// <param name="username"> The username or email address for the user. </param>
        /// <param name="password"> The user's password. </param>
        /// <returns> The user's private token. Null if the username/password was incorrect. </returns>
        public async Task<RequestResult<User>> RequestSession(string username, string password)
        {
            if (username == null)
                throw new ArgumentNullException(nameof(username));

            if (password == null)
                throw new ArgumentNullException(nameof(password));

            var request = RequestFactory.Create("session", Method.Post, false);

            request.AddParameter("login", username);
            request.AddParameter("password", password);

            return await request.Execute<User>();
        }
    }
}