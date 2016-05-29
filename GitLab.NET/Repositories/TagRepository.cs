// ReSharper disable UnusedMember.Global

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.RequestModels;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab Tag access in a repository pattern. </summary>
    public class TagRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="TagRepository" /> instance. </summary>
        /// <param name="restExecutor"> An instance of <see cref="IRequestExecutor" /> to use for this repository. </param>
        public TagRepository(IRequestExecutor restExecutor) : base(restExecutor) { }

        /// <summary> Creates a new tag. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="tagName"> The name for the new tag. </param>
        /// <param name="refName"> The commit sha, branch name, or tag name to associate this tag with. </param>
        /// <param name="message"> The message for this tag. </param>
        /// <param name="releaseDescription"> The release description for this tag. </param>
        /// <returns> A <see cref="RequestResult{Tag}" /> representing the results of the request. </returns>
        public RequestResult<Tag> Create(uint projectId, string tagName, string refName, string message = null, string releaseDescription = null)
        {
            if (tagName == null)
                throw new ArgumentNullException(nameof(tagName));

            if (refName == null)
                throw new ArgumentNullException(nameof(refName));

            var request = new CreateTagRequest(projectId, tagName, refName, message, releaseDescription);

            var result = RequestExecutor.Execute<Tag>(request);

            return new RequestResult<Tag>(result);
        }

        /// <summary> Creates a new tag. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="tagName"> The name for the new tag. </param>
        /// <param name="refName"> The commit sha, branch name, or tag name to associate this tag with. </param>
        /// <param name="message"> The message for this tag. </param>
        /// <param name="releaseDescription"> The release description for this tag. </param>
        /// <returns> A <see cref="RequestResult{Tag}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Tag>> CreateAsync(uint projectId, string tagName, string refName, string message = null, string releaseDescription = null)
        {
            if (tagName == null)
                throw new ArgumentNullException(nameof(tagName));

            if (refName == null)
                throw new ArgumentNullException(nameof(refName));

            var request = new CreateTagRequest(projectId, tagName, refName, message, releaseDescription);

            var result = await RequestExecutor.ExecuteAsync<Tag>(request);

            return new RequestResult<Tag>(result);
        }

        /// <summary> Creates a release associated with the specified tag. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="tagName"> The name of the tag to associate the release with. </param>
        /// <param name="description"> The release description. </param>
        /// <returns> A <see cref="RequestResult{Tag}" /> representing the results of the request. </returns>
        public RequestResult<Tag> CreateRelease(uint projectId, string tagName, string description)
        {
            if (tagName == null)
                throw new ArgumentNullException(nameof(tagName));

            if (description == null)
                throw new ArgumentNullException(nameof(description));

            var request = new CreateReleaseRequest(projectId, tagName, description);

            var result = RequestExecutor.Execute<Tag>(request);

            return new RequestResult<Tag>(result);
        }

        /// <summary> Creates a release associated with the specified tag. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="tagName"> The name of the tag to associate the release with. </param>
        /// <param name="description"> The release description. </param>
        /// <returns> A <see cref="RequestResult{Tag}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Tag>> CreateReleaseAsync(uint projectId, string tagName, string description)
        {
            if (tagName == null)
                throw new ArgumentNullException(nameof(tagName));

            if (description == null)
                throw new ArgumentNullException(nameof(description));

            var request = new CreateReleaseRequest(projectId, tagName, description);

            var result = await RequestExecutor.ExecuteAsync<Tag>(request);

            return new RequestResult<Tag>(result);
        }

        /// <summary> Deletes a tag. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="tagName"> The name of the tag to delete. </param>
        /// <returns> A <see cref="RequestResult{Tag}" /> representing the results of the request. </returns>
        public RequestResult<Tag> Delete(uint projectId, string tagName)
        {
            if (tagName == null)
                throw new ArgumentNullException(nameof(tagName));

            var request = new DeleteTagRequest(projectId, tagName);

            var result = RequestExecutor.Execute<Tag>(request);

            return new RequestResult<Tag>(result);
        }

        /// <summary> Deletes a tag. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="tagName"> The name of the tag to delete. </param>
        /// <returns> A <see cref="RequestResult{Tag}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Tag>> DeleteAsync(uint projectId, string tagName)
        {
            if (tagName == null)
                throw new ArgumentNullException(nameof(tagName));

            var request = new DeleteTagRequest(projectId, tagName);

            var result = await RequestExecutor.ExecuteAsync<Tag>(request);

            return new RequestResult<Tag>(result);
        }

        /// <summary> Gets all tags associated with the specified project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{Tag}" /> representing the results of the
        ///     request.
        /// </returns>
        public RequestResult<List<Tag>> GetAll(uint projectId)
        {
            var request = new GetTagsRequest(projectId);

            var result = RequestExecutor.Execute<List<Tag>>(request);

            return new RequestResult<List<Tag>>(result);
        }

        /// <summary> Gets all tags associated with the specified project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{Tag}" /> representing the results of the
        ///     request.
        /// </returns>
        public async Task<RequestResult<List<Tag>>> GetAllAsync(uint projectId)
        {
            var request = new GetTagsRequest(projectId);

            var result = await RequestExecutor.ExecuteAsync<List<Tag>>(request);

            return new RequestResult<List<Tag>>(result);
        }

        /// <summary> Gets a tag by name. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="tagName"> The name of the desired tag. </param>
        /// <returns> A <see cref="RequestResult{Tag}" /> representing the results of the request. </returns>
        public RequestResult<Tag> GetByName(uint projectId, string tagName)
        {
            if (tagName == null)
                throw new ArgumentNullException(nameof(tagName));

            var request = new GetTagRequest(projectId, tagName);

            var result = RequestExecutor.Execute<Tag>(request);

            return new RequestResult<Tag>(result);
        }

        /// <summary> Gets a tag by name. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="tagName"> The name of the desired tag. </param>
        /// <returns> A <see cref="RequestResult{Tag}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Tag>> GetByNameAsync(uint projectId, string tagName)
        {
            if (tagName == null)
                throw new ArgumentNullException(nameof(tagName));

            var request = new GetTagRequest(projectId, tagName);

            var result = await RequestExecutor.ExecuteAsync<Tag>(request);

            return new RequestResult<Tag>(result);
        }

        /// <summary> Updates a release associated with the specified tag. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="tagName"> The name of the tag the release is associated with. </param>
        /// <param name="description"> The release description. </param>
        /// <returns> A <see cref="RequestResult{Tag}" /> representing the results of the request. </returns>
        public RequestResult<Tag> UpdateRelease(uint projectId, string tagName, string description)
        {
            if (tagName == null)
                throw new ArgumentNullException(nameof(tagName));

            if (description == null)
                throw new ArgumentNullException(nameof(description));

            var request = new UpdateReleaseRequest(projectId, tagName, description);

            var result = RequestExecutor.Execute<Tag>(request);

            return new RequestResult<Tag>(result);
        }

        /// <summary> Updates a release associated with the specified tag. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="tagName"> The name of the tag the release is associated with. </param>
        /// <param name="description"> The release description. </param>
        /// <returns> A <see cref="RequestResult{Tag}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Tag>> UpdateReleaseAsync(uint projectId, string tagName, string description)
        {
            if (tagName == null)
                throw new ArgumentNullException(nameof(tagName));

            if (description == null)
                throw new ArgumentNullException(nameof(description));

            var request = new UpdateReleaseRequest(projectId, tagName, description);

            var result = await RequestExecutor.ExecuteAsync<Tag>(request);

            return new RequestResult<Tag>(result);
        }
    }
}