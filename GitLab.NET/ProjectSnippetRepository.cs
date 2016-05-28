// ReSharper disable UnusedMember.Global

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitLab.NET.RequestModels;
using GitLab.NET.ResponseModels;

namespace GitLab.NET
{
    /// <summary> Provides GitLab Project Snippets access in a repository pattern. </summary>
    public class ProjectSnippetRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="ProjectSnippetRepository" /> instance. </summary>
        /// <param name="restExecutor"> An instance of <see cref="IRequestExecutor" /> to use for this repository. </param>
        public ProjectSnippetRepository(IRequestExecutor restExecutor) : base(restExecutor) { }

        /// <summary> Creates a new project snippet associated with the provided project ID. </summary>
        /// <param name="projectId"> The ID of the project to create this snippet for. </param>
        /// <param name="title"> The snippet's title. </param>
        /// <param name="fileName"> The snippet's file name. </param>
        /// <param name="code"> The code for this snippet. </param>
        /// <param name="visibilityLevel"> The visibility level for this snippet. </param>
        /// <returns> A <see cref="RequestResult{ProjectSnippet}" /> representing the results of the request. </returns>
        public RequestResult<ProjectSnippet> Create(uint projectId, string title, string fileName, string code, VisibilityLevel visibilityLevel)
        {
            if (title == null)
                throw new ArgumentNullException(nameof(title));

            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));

            if (code == null)
                throw new ArgumentNullException(nameof(code));

            var request = new CreateProjectSnippetRequest(projectId, title, fileName, code, visibilityLevel);

            var result = RequestExecutor.Execute<ProjectSnippet>(request);

            return new RequestResult<ProjectSnippet>(result);
        }

        /// <summary> Creates a new project snippet associated with the provided project ID. </summary>
        /// <param name="projectId"> The ID of the project to create this snippet for. </param>
        /// <param name="title"> The snippet's title. </param>
        /// <param name="fileName"> The snippet's file name. </param>
        /// <param name="code"> The code for this snippet. </param>
        /// <param name="visibilityLevel"> The visibility level for this snippet. </param>
        /// <returns> A <see cref="RequestResult{ProjectSnippet}" /> representing the results of the request. </returns>
        public async Task<RequestResult<ProjectSnippet>> CreateAsync(uint projectId, string title, string fileName, string code, VisibilityLevel visibilityLevel)
        {
            if (title == null)
                throw new ArgumentNullException(nameof(title));

            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));

            if (code == null)
                throw new ArgumentNullException(nameof(code));

            var request = new CreateProjectSnippetRequest(projectId, title, fileName, code, visibilityLevel);

            var result = await RequestExecutor.ExecuteAsync<ProjectSnippet>(request);

            return new RequestResult<ProjectSnippet>(result);
        }

        /// <summary> Deletes a project snippet. </summary>
        /// <param name="id"> </param>
        /// <param name="projectId"> </param>
        /// <returns> A <see cref="RequestResult{ProjectSnippet}" /> representing the results of the request. </returns>
        public RequestResult<ProjectSnippet> Delete(uint id, uint projectId)
        {
            var request = new DeleteProjectSnippetRequest(id, projectId);

            var result = RequestExecutor.Execute<ProjectSnippet>(request);

            return new RequestResult<ProjectSnippet>(result);
        }

        /// <summary> Deletes a project snippet. </summary>
        /// <param name="id"> </param>
        /// <param name="projectId"> </param>
        /// <returns> A <see cref="RequestResult{ProjectSnippet}" /> representing the results of the request. </returns>
        public async Task<RequestResult<ProjectSnippet>> DeleteAsync(uint id, uint projectId)
        {
            var request = new DeleteProjectSnippetRequest(id, projectId);

            var result = await RequestExecutor.ExecuteAsync<ProjectSnippet>(request);

            return new RequestResult<ProjectSnippet>(result);
        }

        /// <summary> Gets all of the project snippets associated with a project. </summary>
        /// <param name="projectId"> The ID of the project to get snippets from. </param>
        /// <returns> A <see cref="PaginatedResult{ProjectSnippet}" /> representing the results of the request. </returns>
        public PaginatedResult<ProjectSnippet> GetAll(uint projectId)
        {
            var request = new GetProjectSnippetsRequest(projectId);

            var result = RequestExecutor.Execute<List<ProjectSnippet>>(request);

            return new PaginatedResult<ProjectSnippet>(result);
        }

        /// <summary> Gets all of the project snippets associated with a project. </summary>
        /// <param name="projectId"> The ID of the project to get snippets from. </param>
        /// <returns> A <see cref="PaginatedResult{ProjectSnippet}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<ProjectSnippet>> GetAllAsync(uint projectId)
        {
            var request = new GetProjectSnippetsRequest(projectId);

            var result = await RequestExecutor.ExecuteAsync<List<ProjectSnippet>>(request);

            return new PaginatedResult<ProjectSnippet>(result);
        }

        /// <summary> Gets a snippet by its ID and the project ID it is associated with. </summary>
        /// <param name="id"> The ID of the snippet to retrieve. </param>
        /// <param name="projectId"> The ID of the project to get snippets from. </param>
        /// <returns> A <see cref="RequestResult{ProjectSnippet}" /> representing the results of the request. </returns>
        public RequestResult<ProjectSnippet> GetById(uint id, uint projectId)
        {
            var request = new GetProjectSnippetRequest(id, projectId);

            var result = RequestExecutor.Execute<ProjectSnippet>(request);

            return new RequestResult<ProjectSnippet>(result);
        }

        /// <summary> Gets a snippet by its ID and the project ID it is associated with. </summary>
        /// <param name="id"> The ID of the snippet to retrieve. </param>
        /// <param name="projectId"> The ID of the project to get snippets from. </param>
        /// <returns> A <see cref="RequestResult{ProjectSnippet}" /> representing the results of the request. </returns>
        public async Task<RequestResult<ProjectSnippet>> GetByIdAsync(uint id, uint projectId)
        {
            var request = new GetProjectSnippetRequest(id, projectId);

            var result = await RequestExecutor.ExecuteAsync<ProjectSnippet>(request);

            return new RequestResult<ProjectSnippet>(result);
        }

        /// <summary> Gets a snippet's content by its ID and the project ID it is associated with. </summary>
        /// <param name="id"> The ID of the snippet. </param>
        /// <param name="projectId"> The ID of the project to get the snippet from. </param>
        /// <returns> A <see cref="RequestResult{String}" /> representing the results of the request. </returns>
        public RequestResult<string> GetContent(uint id, uint projectId)
        {
            var request = new GetProjectSnippetContentRequest(id, projectId);

            var result = RequestExecutor.Execute(request);

            return new RequestResult<string>(result, result.Content);
        }

        /// <summary> Gets a snippet's content by its ID and the project ID it is associated with. </summary>
        /// <param name="id"> The ID of the snippet. </param>
        /// <param name="projectId"> The ID of the project to get the snippet from. </param>
        /// <returns> A <see cref="RequestResult{String}" /> representing the results of the request. </returns>
        public async Task<RequestResult<string>> GetContentAsync(uint id, uint projectId)
        {
            var request = new GetProjectSnippetContentRequest(id, projectId);

            var result = await RequestExecutor.ExecuteAsync(request);

            return new RequestResult<string>(result, result.Content);
        }

        /// <summary> Updates a project snippet associated with the provided project ID. </summary>
        /// <param name="projectId"> The ID of the project the snippet is attached to. </param>
        /// <param name="id"> The ID of the snippet to update. </param>
        /// <param name="title"> The snippet's title. </param>
        /// <param name="fileName"> The snippet's file name. </param>
        /// <param name="code"> The code for this snippet. </param>
        /// <param name="visibilityLevel"> The visibility level for this snippet. </param>
        /// <returns> A <see cref="RequestResult{ProjectSnippet}" /> representing the results of the request. </returns>
        public RequestResult<ProjectSnippet> Update(uint projectId, uint id, string title = null, string fileName = null, string code = null, VisibilityLevel? visibilityLevel = null)
        {
            var request = new UpdateProjectSnippetRequest(projectId, id, title, fileName, code, visibilityLevel);

            var result = RequestExecutor.Execute<ProjectSnippet>(request);

            return new RequestResult<ProjectSnippet>(result);
        }

        /// <summary> Updates a project snippet associated with the provided project ID. </summary>
        /// <param name="projectId"> The ID of the project the snippet is attached to. </param>
        /// <param name="id"> The ID of the snippet to update. </param>
        /// <param name="title"> The snippet's title. </param>
        /// <param name="fileName"> The snippet's file name. </param>
        /// <param name="code"> The code for this snippet. </param>
        /// <param name="visibilityLevel"> The visibility level for this snippet. </param>
        /// <returns> A <see cref="RequestResult{ProjectSnippet}" /> representing the results of the request. </returns>
        public async Task<RequestResult<ProjectSnippet>> UpdateAsync(uint projectId, uint id, string title = null, string fileName = null, string code = null, VisibilityLevel? visibilityLevel = null)
        {
            var request = new UpdateProjectSnippetRequest(projectId, id, title, fileName, code, visibilityLevel);

            var result = await RequestExecutor.ExecuteAsync<ProjectSnippet>(request);

            return new RequestResult<ProjectSnippet>(result);
        }
    }
}