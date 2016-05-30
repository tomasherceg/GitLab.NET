// ReSharper disable UnusedMember.Global

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab Email access in a repository pattern. </summary>
    public class EmailRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="EmailRepository" /> instance. </summary>
        /// <param name="requestFactory"> An instance of <see cref="IRequestFactory" /> to use for this repository. </param>
        public EmailRepository(IRequestFactory requestFactory) : base(requestFactory) { }

        /// <summary> Adds an email address to the currently authenticated user's account or the specified user's account. </summary>
        /// <param name="email"> The email address to add. </param>
        /// <param name="userId"> The user's ID. </param>
        /// <returns> A <see cref="RequestResult{EmailAddress}" /> representing the results of the request. </returns>
        public RequestResult<EmailAddress> Create(string email, uint? userId = null)
        {
            if (email == null)
                throw new ArgumentNullException(nameof(email));

            var resource = userId != null ? "users/{userId}/emails" : "user/emails";
            var request = RequestFactory.Create(resource, Method.Post);

            request.AddParameter("email", email);
            request.AddUrlSegmentIfNotNull("userId", userId);

            return request.Execute<EmailAddress>();
        }

        /// <summary> Adds an email address to the currently authenticated user's account or the specified user's account. </summary>
        /// <param name="email"> The email address to add. </param>
        /// <param name="userId"> The user's ID. </param>
        /// <returns> A <see cref="RequestResult{EmailAddress}" /> representing the results of the request. </returns>
        public async Task<RequestResult<EmailAddress>> CreateAsync(string email, uint? userId = null)
        {
            if (email == null)
                throw new ArgumentNullException(nameof(email));

            var resource = userId != null ? "users/{userId}/emails" : "user/emails";
            var request = RequestFactory.Create(resource, Method.Post);

            request.AddParameter("email", email);
            request.AddUrlSegmentIfNotNull("userId", userId);

            return await request.ExecuteAsync<EmailAddress>();
        }

        /// <summary> Deletes an email address from the current user's account. </summary>
        /// <param name="id"> The ID of the email address to delete. </param>
        /// <param name="userId"> The user's ID. </param>
        /// <returns> A <see cref="RequestResult{EmailAddress}" /> representing the results of the request. </returns>
        public RequestResult<EmailAddress> Delete(uint id, uint? userId = null)
        {
            var resource = userId != null ? "users/{userId}/emails/{id}" : "user/emails/{id}";
            var request = RequestFactory.Create(resource, Method.Delete);

            request.AddUrlSegment("id", id);
            request.AddUrlSegmentIfNotNull("userId", userId);

            return request.Execute<EmailAddress>();
        }

        /// <summary> Deletes an email address from the current user's account. </summary>
        /// <param name="id"> The ID of the email address to delete. </param>
        /// <param name="userId"> The user's ID. </param>
        /// <returns> A <see cref="RequestResult{EmailAddress}" /> representing the results of the request. </returns>
        public async Task<RequestResult<EmailAddress>> DeleteAsync(uint id, uint? userId = null)
        {
            var resource = userId != null ? "users/{userId}/emails/{id}" : "user/emails/{id}";
            var request = RequestFactory.Create(resource, Method.Delete);

            request.AddUrlSegment("id", id);
            request.AddUrlSegmentIfNotNull("userId", userId);

            return await request.ExecuteAsync<EmailAddress>();
        }

        /// <summary> Gets an email address by ID. </summary>
        /// <param name="id"> The ID of the email address. </param>
        /// <returns> A <see cref="RequestResult{EmailAddress}" /> representing the results of the request. </returns>
        public RequestResult<EmailAddress> Find(uint id)
        {
            var request = RequestFactory.Create("user/emails/{id}", Method.Get);

            request.AddUrlSegment("id", id);

            return request.Execute<EmailAddress>();
        }

        /// <summary> Gets an email address by ID. </summary>
        /// <param name="id"> The ID of the email address. </param>
        /// <returns> A <see cref="RequestResult{EmailAddress}" /> representing the results of the request. </returns>
        public async Task<RequestResult<EmailAddress>> FindAsync(uint id)
        {
            var request = RequestFactory.Create("user/emails/{id}", Method.Get);

            request.AddUrlSegment("id", id);

            return await request.ExecuteAsync<EmailAddress>();
        }

        /// <summary> Gets the email addresses attached to the currently authenticated user's account or the specified user's account. </summary>
        /// <param name="userId"> The user's ID. </param>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{EmailAddress}" /> representing the results of
        ///     the request.
        /// </returns>
        public RequestResult<List<EmailAddress>> GetForUser(uint? userId = null)
        {
            var resource = userId != null ? "users/{userId}/emails" : "user/emails";
            var request = RequestFactory.Create(resource, Method.Get);

            request.AddUrlSegmentIfNotNull("userId", userId);

            return request.Execute<List<EmailAddress>>();
        }

        /// <summary> Gets the email addresses attached to the currently authenticated user's account or the specified user's account. </summary>
        /// <param name="userId"> The user's ID. </param>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{EmailAddress}" /> representing the results of
        ///     the request.
        /// </returns>
        public async Task<RequestResult<List<EmailAddress>>> GetForUserAsync(uint? userId = null)
        {
            var resource = userId != null ? "users/{userId}/emails" : "user/emails";
            var request = RequestFactory.Create(resource, Method.Get);

            request.AddUrlSegmentIfNotNull("userId", userId);

            return await request.ExecuteAsync<List<EmailAddress>>();
        }
    }
}