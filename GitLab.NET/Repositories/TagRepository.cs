using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab Tag access in a repository pattern. </summary>
    public class TagRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="TagRepository" /> instance. </summary>
        /// <param name="requestFactory"> An instance of <see cref="IRequestFactory" /> to use for this repository. </param>
        public TagRepository(IRequestFactory requestFactory) : base(requestFactory) { }

        /// <summary> Creates a new tag. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="tagName"> The name for the new tag. </param>
        /// <param name="refName"> The commit sha, branch name, or tag name to associate this tag with. </param>
        /// <param name="message"> The message for this tag. </param>
        /// <param name="releaseDescription"> The release description for this tag. </param>
        /// <returns> A <see cref="RequestResult{Tag}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Tag>> Create(uint projectId, string tagName, string refName, string message = null, string releaseDescription = null)
        {
            if (tagName == null)
                throw new ArgumentNullException(nameof(tagName));

            if (refName == null)
                throw new ArgumentNullException(nameof(refName));

            var request = RequestFactory.Create("projects/{projectId}/repository/tags", Method.Post);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameter("tag_name", tagName);
            request.AddParameter("ref", refName);
            request.AddParameterIfNotNull("message", message);
            request.AddParameterIfNotNull("release_description", releaseDescription);

            return await request.Execute<Tag>();
        }

        /// <summary> Creates a release associated with the specified tag. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="tagName"> The name of the tag to associate the release with. </param>
        /// <param name="description"> The release description. </param>
        /// <returns> A <see cref="RequestResult{Tag}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Tag>> CreateRelease(uint projectId, string tagName, string description)
        {
            if (tagName == null)
                throw new ArgumentNullException(nameof(tagName));

            if (description == null)
                throw new ArgumentNullException(nameof(description));

            var request = RequestFactory.Create("projects/{projectId}/repository/tags/{tagName}/release", Method.Post);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("tagName", tagName);
            request.AddParameter("description", description);

            return await request.Execute<Tag>();
        }

        /// <summary> Deletes a tag. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="tagName"> The name of the tag to delete. </param>
        /// <returns> A <see cref="RequestResult{Tag}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Tag>> Delete(uint projectId, string tagName)
        {
            if (tagName == null)
                throw new ArgumentNullException(nameof(tagName));

            var request = RequestFactory.Create("projects/{projectId}/repository/tags/{tagName}", Method.Delete);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("tagName", tagName);

            return await request.Execute<Tag>();
        }

        /// <summary> Finds a tag by name. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="tagName"> The name of the desired tag. </param>
        /// <returns> A <see cref="RequestResult{Tag}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Tag>> Find(uint projectId, string tagName)
        {
            if (tagName == null)
                throw new ArgumentNullException(nameof(tagName));

            var request = RequestFactory.Create("projects/{projectId}/repository/tags/{tagName}", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("tagName", tagName);

            return await request.Execute<Tag>();
        }

        /// <summary> Gets all tags associated with the specified project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{Tag}" /> representing the results of the
        ///     request.
        /// </returns>
        public async Task<RequestResult<List<Tag>>> GetAll(uint projectId)
        {
            var request = RequestFactory.Create("projects/{projectId}/repository/tags", Method.Get);

            request.AddUrlSegment("projectId", projectId);

            return await request.Execute<List<Tag>>();
        }

        /// <summary> Updates a release associated with the specified tag. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="tagName"> The name of the tag the release is associated with. </param>
        /// <param name="description"> The release description. </param>
        /// <returns> A <see cref="RequestResult{Tag}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Tag>> UpdateRelease(uint projectId, string tagName, string description)
        {
            if (tagName == null)
                throw new ArgumentNullException(nameof(tagName));

            if (description == null)
                throw new ArgumentNullException(nameof(description));

            var request = RequestFactory.Create("projects/{projectId}/repository/tags/{tagName}/release", Method.Put);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("tagName", tagName);
            request.AddParameter("description", description);

            return await request.Execute<Tag>();
        }
    }
}