// ReSharper disable UnusedMember.Global

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.RequestModels;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab Label access in a repository pattern. </summary>
    public class LabelRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="LabelRepository" /> instance. </summary>
        /// <param name="restExecutor"> An instance of <see cref="IRequestExecutor" /> to use for this repository. </param>
        public LabelRepository(IRequestExecutor restExecutor) : base(restExecutor) { }

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

            var request = new CreateLabelRequest(projectId, name, color, description);

            var result = RequestExecutor.Execute<Label>(request);

            return new RequestResult<Label>(result);
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

            var request = new CreateLabelRequest(projectId, name, color, description);

            var result = await RequestExecutor.ExecuteAsync<Label>(request);

            return new RequestResult<Label>(result);
        }

        /// <summary> Deletes a label. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="name"> The name of the label to delete. </param>
        /// <returns> A <see cref="RequestResult{Label}" /> representing the results of this request. </returns>
        public RequestResult<Label> Delete(uint projectId, string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var request = new DeleteLabelRequest(projectId, name);

            var result = RequestExecutor.Execute<Label>(request);

            return new RequestResult<Label>(result);
        }

        /// <summary> Deletes a label. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="name"> The name of the label to delete. </param>
        /// <returns> A <see cref="RequestResult{Label}" /> representing the results of this request. </returns>
        public async Task<RequestResult<Label>> DeleteAsync(uint projectId, string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var request = new DeleteLabelRequest(projectId, name);

            var result = await RequestExecutor.ExecuteAsync<Label>(request);

            return new RequestResult<Label>(result);
        }

        /// <summary> Gets all labels attached to the specified project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{Label}" /> representing the results of the
        ///     request.
        /// </returns>
        public RequestResult<List<Label>> GetAll(uint projectId)
        {
            var request = new GetLabelsRequest(projectId);

            var result = RequestExecutor.Execute<List<Label>>(request);

            return new RequestResult<List<Label>>(result);
        }

        /// <summary> Gets all labels attached to the specified project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{Label}" /> representing the results of the
        ///     request.
        /// </returns>
        public async Task<RequestResult<List<Label>>> GetAllAsync(uint projectId)
        {
            var request = new GetLabelsRequest(projectId);

            var result = await RequestExecutor.ExecuteAsync<List<Label>>(request);

            return new RequestResult<List<Label>>(result);
        }

        /// <summary> Subscribes to a label. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="name"> The name of the label to subscribe to. </param>
        /// <returns> A <see cref="RequestResult{Label}" /> representing the results of the request. </returns>
        public RequestResult<Label> Subscribe(uint projectId, string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var request = new SubscribeLabelRequest(projectId, name);

            var result = RequestExecutor.Execute<Label>(request);

            return new RequestResult<Label>(result);
        }

        /// <summary> Subscribes to a label. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="name"> The name of the label to subscribe to. </param>
        /// <returns> A <see cref="RequestResult{Label}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Label>> SubscribeAsync(uint projectId, string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var request = new SubscribeLabelRequest(projectId, name);

            var result = await RequestExecutor.ExecuteAsync<Label>(request);

            return new RequestResult<Label>(result);
        }

        /// <summary> Unsubscribes from a label. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="name"> The name of the label to unsubscribe from. </param>
        /// <returns> A <see cref="RequestResult{Label}" /> representing the results of the request. </returns>
        public RequestResult<Label> Unsubscribe(uint projectId, string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var request = new UnsubscribeLabelRequest(projectId, name);

            var result = RequestExecutor.Execute<Label>(request);

            return new RequestResult<Label>(result);
        }

        /// <summary> Unsubscribes from a label. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="name"> The name of the label to unsubscribe from. </param>
        /// <returns> A <see cref="RequestResult{Label}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Label>> UnsubscribeAsync(uint projectId, string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            var request = new UnsubscribeLabelRequest(projectId, name);

            var result = await RequestExecutor.ExecuteAsync<Label>(request);

            return new RequestResult<Label>(result);
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

            var request = new UpdateLabelRequest(projectId, name, newName, color, description);

            var result = RequestExecutor.Execute<Label>(request);

            return new RequestResult<Label>(result);
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

            var request = new UpdateLabelRequest(projectId, name, newName, color, description);

            var result = await RequestExecutor.ExecuteAsync<Label>(request);

            return new RequestResult<Label>(result);
        }
    }
}