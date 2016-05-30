using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab Label access in a repository pattern. </summary>
    public class LabelRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="LabelRepository" /> instance. </summary>
        /// <param name="requestFactory"> An instance of <see cref="IRequestFactory" /> to use for this repository. </param>
        public LabelRepository(IRequestFactory requestFactory) : base(requestFactory) { }

        /// <summary> Creates a new label. </summary>
        /// <param name="projectId"> The ID of the project to attach this label to. </param>
        /// <param name="name"> The name for the new label. </param>
        /// <param name="color"> The color for the new label. </param>
        /// <param name="description"> The description for the new label. </param>
        /// <returns> A <see cref="RequestResult{Label}" /> representing the results of the request. </returns>
        public RequestResult<Label> Create(uint projectId, string name, string color, string description = null)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (color == null)
                throw new ArgumentNullException(nameof(color));

            var request = RequestFactory.Create("projects/{projectId}/labels", Method.Post);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameter("name", name);
            request.AddParameter("color", color);
            request.AddParameterIfNotNull("description", description);

            return request.Execute<Label>();
        }

        /// <summary> Creates a new label. </summary>
        /// <param name="projectId"> The ID of the project to attach this label to. </param>
        /// <param name="name"> The name for the new label. </param>
        /// <param name="color"> The color for the new label. </param>
        /// <param name="description"> The description for the new label. </param>
        /// <returns> A <see cref="RequestResult{Label}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Label>> CreateAsync(uint projectId, string name, string color, string description = null)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (color == null)
                throw new ArgumentNullException(nameof(color));

            var request = RequestFactory.Create("projects/{projectId}/labels", Method.Post);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameter("name", name);
            request.AddParameter("color", color);
            request.AddParameterIfNotNull("description", description);

            return await request.ExecuteAsync<Label>();
        }

        /// <summary> Deletes a label. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="name"> The name of the label to delete. </param>
        /// <returns> A <see cref="RequestResult{Label}" /> representing the results of this request. </returns>
        public RequestResult<Label> Delete(uint projectId, string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var request = RequestFactory.Create("projects/{projectId}/labels", Method.Delete);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameter("name", name);

            return request.Execute<Label>();
        }

        /// <summary> Deletes a label. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="name"> The name of the label to delete. </param>
        /// <returns> A <see cref="RequestResult{Label}" /> representing the results of this request. </returns>
        public async Task<RequestResult<Label>> DeleteAsync(uint projectId, string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var request = RequestFactory.Create("projects/{projectId}/labels", Method.Delete);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameter("name", name);

            return await request.ExecuteAsync<Label>();
        }

        /// <summary> Gets all labels attached to the specified project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{Label}" /> representing the results of the
        ///     request.
        /// </returns>
        public RequestResult<List<Label>> GetAll(uint projectId)
        {
            var request = RequestFactory.Create("projects/{projectId}/labels", Method.Get);

            request.AddUrlSegment("projectId", projectId);

            return request.Execute<List<Label>>();
        }

        /// <summary> Gets all labels attached to the specified project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{Label}" /> representing the results of the
        ///     request.
        /// </returns>
        public async Task<RequestResult<List<Label>>> GetAllAsync(uint projectId)
        {
            var request = RequestFactory.Create("projects/{projectId}/labels", Method.Get);

            request.AddUrlSegment("projectId", projectId);

            return await request.ExecuteAsync<List<Label>>();
        }

        /// <summary> Subscribes to a label. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="name"> The name of the label to subscribe to. </param>
        /// <returns> A <see cref="RequestResult{Label}" /> representing the results of the request. </returns>
        public RequestResult<Label> Subscribe(uint projectId, string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var request = RequestFactory.Create("projects/{projectId}/labels/{labelId}/subscription", Method.Post);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("labelId", name);

            return request.Execute<Label>();
        }

        /// <summary> Subscribes to a label. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="name"> The name of the label to subscribe to. </param>
        /// <returns> A <see cref="RequestResult{Label}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Label>> SubscribeAsync(uint projectId, string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var request = RequestFactory.Create("projects/{projectId}/labels/{labelId}/subscription", Method.Post);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("labelId", name);

            return await request.ExecuteAsync<Label>();
        }

        /// <summary> Unsubscribes from a label. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="name"> The name of the label to unsubscribe from. </param>
        /// <returns> A <see cref="RequestResult{Label}" /> representing the results of the request. </returns>
        public RequestResult<Label> Unsubscribe(uint projectId, string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var request = RequestFactory.Create("projects/{projectId}/labels/{labelId}/subscription", Method.Delete);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("labelId", name);

            return request.Execute<Label>();
        }

        /// <summary> Unsubscribes from a label. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="name"> The name of the label to unsubscribe from. </param>
        /// <returns> A <see cref="RequestResult{Label}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Label>> UnsubscribeAsync(uint projectId, string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var request = RequestFactory.Create("projects/{projectId}/labels/{labelId}/subscription", Method.Delete);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("labelId", name);

            return await request.ExecuteAsync<Label>();
        }

        /// <summary> Updates a label. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="name"> The name for the label. </param>
        /// <param name="newName"> The new name for the label. </param>
        /// <param name="color"> The new color for the label. </param>
        /// <param name="description"> The new description for the label. </param>
        /// <returns> A <see cref="RequestResult{Label}" /> representing the results of the request. </returns>
        public RequestResult<Label> Update(uint projectId, string name, string newName = null, string color = null, string description = null)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (newName == null && color == null && description == null)
                throw new NullReferenceException("You must provide at least one parameter.");

            var request = RequestFactory.Create("projects/{projectId}/labels", Method.Put);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameter("name", name);
            request.AddParameterIfNotNull("new_name", newName);
            request.AddParameterIfNotNull("color", color);
            request.AddParameterIfNotNull("description", description);

            return request.Execute<Label>();
        }

        /// <summary> Updates a label. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="name"> The name for the label. </param>
        /// <param name="newName"> The new name for the label. </param>
        /// <param name="color"> The new color for the label. </param>
        /// <param name="description"> The new description for the label. </param>
        /// <returns> A <see cref="RequestResult{Label}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Label>> UpdateAsync(uint projectId, string name, string newName = null, string color = null, string description = null)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var request = RequestFactory.Create("projects/{projectId}/labels", Method.Put);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameter("name", name);
            request.AddParameterIfNotNull("new_name", newName);
            request.AddParameterIfNotNull("color", color);
            request.AddParameterIfNotNull("description", description);

            return await request.ExecuteAsync<Label>();
        }
    }
}