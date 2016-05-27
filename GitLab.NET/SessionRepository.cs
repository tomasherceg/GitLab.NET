using System;
using System.Threading.Tasks;
using GitLab.NET.RequestModels;
using GitLab.NET.ResponseModels;

namespace GitLab.NET
{
    /// <summary>
    ///     Retrieves a private token for a given username/password combination.
    /// </summary>
    public class SessionRepository : RepositoryBase
    {
        
        /// <summary>
        ///     Creates a new <see cref="SessionRepository" /> instance.
        /// </summary>
        /// <param name="restExecutor">An instance of <see cref="IRequestExecutor" /> to use for this repository.</param>
        public SessionRepository(IRequestExecutor restExecutor) : base(restExecutor) { }

        /// <summary>
        ///     Synchronously retrieves a private token for a user.
        /// </summary>
        /// <param name="username">The username or email address for the user.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>The user's private token. Null if the username/password was incorrect.</returns>
        public RequestResult<User> RequestSession(string username, string password)
        {
            if (username == null)
                throw new ArgumentNullException(nameof(username));

            if (password == null)
                throw new ArgumentNullException(nameof(password));

            var request = new CreateSessionRequest(username, password);

            var response = RequestExecutor.Execute<User>(request, false);
            
            return new RequestResult<User>(response);
        }

        /// <summary>
        ///     Asynchronously retrieves a private token for a user.
        /// </summary>
        /// <param name="username">The username or email address for the user.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>The user's private token. Null if the username/password was incorrect.</returns>
        public async Task<RequestResult<User>> RequestSessionAsync(string username, string password)
        {
            if (username == null)
                throw new ArgumentNullException(nameof(username));

            if (password == null)
                throw new ArgumentNullException(nameof(password));

            var request = new CreateSessionRequest(username, password);

            var response = await RequestExecutor.ExecuteAsync<User>(request, false);

            return new RequestResult<User>(response);
        }
    }
}