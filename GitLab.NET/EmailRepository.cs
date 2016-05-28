// ReSharper disable UnusedMember.Global

using System.Collections.Generic;
using System.Threading.Tasks;
using GitLab.NET.RequestModels;
using GitLab.NET.ResponseModels;

namespace GitLab.NET
{
    /// <summary> Provides GitLab Email access in a repository pattern. </summary>
    public class EmailRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="EmailRepository" /> instance. </summary>
        /// <param name="restExecutor"> An instance of <see cref="IRequestExecutor" /> to use for this repository. </param>
        public EmailRepository(IRequestExecutor restExecutor) : base(restExecutor) { }

        /// <summary> Adds an email address to the currently authenticated user's account. </summary>
        /// <param name="email"> The email address to add. </param>
        /// <returns> A <see cref="RequestResult{EmailAddress}" /> representing the results of the request. </returns>
        public RequestResult<EmailAddress> Add(string email)
        {
            var request = new CreateEmailRequest(email);

            var result = RequestExecutor.Execute<EmailAddress>(request);

            return new RequestResult<EmailAddress>(result);
        }

        /// <summary> Adds an email address to the currently authenticated user's account. </summary>
        /// <param name="email"> The email address to add. </param>
        /// <returns> A <see cref="RequestResult{EmailAddress}" /> representing the results of the request. </returns>
        public async Task<RequestResult<EmailAddress>> AddAsync(string email)
        {
            var request = new CreateEmailRequest(email);

            var result = await RequestExecutor.ExecuteAsync<EmailAddress>(request);

            return new RequestResult<EmailAddress>(result);
        }

        /// <summary> Adds an email address to the specified user's account. </summary>
        /// <param name="userId"> The user's ID. </param>
        /// <param name="email"> The email address to add. </param>
        /// <returns> A <see cref="RequestResult{EmailAddress}" /> representing the results of the request. </returns>
        public RequestResult<EmailAddress> Add(uint userId, string email)
        {
            var request = new CreateEmailRequest(userId, email);

            var result = RequestExecutor.Execute<EmailAddress>(request);

            return new RequestResult<EmailAddress>(result);
        }

        /// <summary> Adds an email address to the specified user's account. </summary>
        /// <param name="userId"> The user's ID. </param>
        /// <param name="email"> The email address to add. </param>
        /// <returns> A <see cref="RequestResult{EmailAddress}" /> representing the results of the request. </returns>
        public async Task<RequestResult<EmailAddress>> AddAsync(uint userId, string email)
        {
            var request = new CreateEmailRequest(userId, email);

            var result = await RequestExecutor.ExecuteAsync<EmailAddress>(request);

            return new RequestResult<EmailAddress>(result);
        }

        /// <summary> Deletes an email address from the current user's account. </summary>
        /// <param name="id"> The ID of the email address to delete. </param>
        /// <returns> A <see cref="RequestResult{EmailAddress}" /> representing the results of the request. </returns>
        public RequestResult<EmailAddress> Delete(uint id)
        {
            var request = new DeleteEmailRequest(id);

            var result = RequestExecutor.Execute<EmailAddress>(request);

            return new RequestResult<EmailAddress>(result);
        }

        /// <summary> Deletes an email address from the current user's account. </summary>
        /// <param name="id"> The ID of the email address to delete. </param>
        /// <returns> A <see cref="RequestResult{EmailAddress}" /> representing the results of the request. </returns>
        public async Task<RequestResult<EmailAddress>> DeleteAsync(uint id)
        {
            var request = new DeleteEmailRequest(id);

            var result = await RequestExecutor.ExecuteAsync<EmailAddress>(request);

            return new RequestResult<EmailAddress>(result);
        }

        /// <summary> Deletes an email address from the specified user's account. </summary>
        /// <param name="id"> The ID of the email address to delete. </param>
        /// <param name="userId"> The user's ID. </param>
        /// <returns> A <see cref="RequestResult{EmailAddress}" /> representing the results of the request. </returns>
        public RequestResult<EmailAddress> Delete(uint id, uint userId)
        {
            var request = new DeleteEmailRequest(id, userId);

            var result = RequestExecutor.Execute<EmailAddress>(request);

            return new RequestResult<EmailAddress>(result);
        }

        /// <summary> Deletes an email address from the specified user's account. </summary>
        /// <param name="id"> The ID of the email address to delete. </param>
        /// <param name="userId"> The user's ID. </param>
        /// <returns> A <see cref="RequestResult{EmailAddress}" /> representing the results of the request. </returns>
        public async Task<RequestResult<EmailAddress>> DeleteAsync(uint id, uint userId)
        {
            var request = new DeleteEmailRequest(id, userId);

            var result = await RequestExecutor.ExecuteAsync<EmailAddress>(request);

            return new RequestResult<EmailAddress>(result);
        }

        /// <summary> Gets an email address by ID. </summary>
        /// <param name="id"> The ID of the email address. </param>
        /// <returns> A <see cref="RequestResult{EmailAddress}" /> representing the results of the request. </returns>
        public RequestResult<EmailAddress> GetById(uint id)
        {
            var request = new GetEmailsRequest(id);

            var result = RequestExecutor.Execute<EmailAddress>(request);

            return new RequestResult<EmailAddress>(result);
        }

        /// <summary> Gets an email address by ID. </summary>
        /// <param name="id"> The ID of the email address. </param>
        /// <returns> A <see cref="RequestResult{EmailAddress}" /> representing the results of the request. </returns>
        public async Task<RequestResult<EmailAddress>> GetByIdAsync(uint id)
        {
            var request = new GetEmailsRequest(id);

            var result = await RequestExecutor.ExecuteAsync<EmailAddress>(request);

            return new RequestResult<EmailAddress>(result);
        }

        /// <summary> Gets the email addresses attached to the currently authenticated user's account. </summary>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{EmailAddress}" /> representing the results of
        ///     the request.
        /// </returns>
        public RequestResult<List<EmailAddress>> GetForUser()
        {
            var request = new GetUserEmailsRequest();

            var result = RequestExecutor.Execute<List<EmailAddress>>(request);

            return new RequestResult<List<EmailAddress>>(result);
        }

        /// <summary> Gets the email addresses attached to the currently authenticated user's account. </summary>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{EmailAddress}" /> representing the results of
        ///     the request.
        /// </returns>
        public async Task<RequestResult<List<EmailAddress>>> GetForUserAsync()
        {
            var request = new GetUserEmailsRequest();

            var result = await RequestExecutor.ExecuteAsync<List<EmailAddress>>(request);

            return new RequestResult<List<EmailAddress>>(result);
        }

        /// <summary> Gets the email addresses attached to the specified user's account. </summary>
        /// <param name="userId"> The user's ID. </param>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{EmailAddress}" /> representing the results of
        ///     the request.
        /// </returns>
        public RequestResult<List<EmailAddress>> GetForUser(uint userId)
        {
            var request = new GetUserEmailsRequest(userId);

            var result = RequestExecutor.Execute<List<EmailAddress>>(request);

            return new RequestResult<List<EmailAddress>>(result);
        }

        /// <summary> Gets the email addresses attached to the specified user's account. </summary>
        /// <param name="userId"> The user's ID. </param>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{EmailAddress}" /> representing the results of
        ///     the request.
        /// </returns>
        public async Task<RequestResult<List<EmailAddress>>> GetForUserAsync(uint userId)
        {
            var request = new GetUserEmailsRequest(userId);

            var result = await RequestExecutor.ExecuteAsync<List<EmailAddress>>(request);

            return new RequestResult<List<EmailAddress>>(result);
        }
    }
}