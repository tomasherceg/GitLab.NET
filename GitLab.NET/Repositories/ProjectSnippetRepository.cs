﻿using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab Project Snippets access in a repository pattern. </summary>
    public class ProjectSnippetRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="ProjectSnippetRepository" /> instance. </summary>
        /// <param name="requestFactory"> An instance of <see cref="IRequestFactory" /> to use for this repository. </param>
        public ProjectSnippetRepository(IRequestFactory requestFactory) : base(requestFactory)
        {
        }

        /// <summary> Creates a new project snippet associated with the provided project ID. </summary>
        /// <param name="projectId"> The ID of the project to create this snippet for. </param>
        /// <param name="title"> The snippet's title. </param>
        /// <param name="fileName"> The snippet's file name. </param>
        /// <param name="code"> The code for this snippet. </param>
        /// <param name="visibilityLevel"> The visibility level for this snippet. </param>
        /// <returns> A <see cref="RequestResult{ProjectSnippet}" /> representing the results of the request. </returns>
        public async Task<RequestResult<ProjectSnippet>> Create(uint projectId, string title, string fileName,
            string code, VisibilityLevel visibilityLevel)
        {
            if (title == null)
                throw new ArgumentNullException(nameof(title));

            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));

            if (code == null)
                throw new ArgumentNullException(nameof(code));

            var request = RequestFactory.Create("projects/{projectId}/snippets", Method.Post);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameter("title", title);
            request.AddParameter("file_name", fileName);
            request.AddParameter("code", code);
            request.AddParameter("visibility_level", visibilityLevel);

            return await request.Execute<ProjectSnippet>();
        }

        /// <summary> Deletes a project snippet. </summary>
        /// <param name="id"> </param>
        /// <param name="projectId"> </param>
        /// <returns> A <see cref="RequestResult{ProjectSnippet}" /> representing the results of the request. </returns>
        public async Task<RequestResult<ProjectSnippet>> Delete(uint id, uint projectId)
        {
            var request = RequestFactory.Create("projects/{projectId}/snippets/{id}", Method.Delete);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("id", id);

            return await request.Execute<ProjectSnippet>();
        }

        /// <summary> Finds a snippet by its ID and the project ID it is associated with. </summary>
        /// <param name="id"> The ID of the snippet to retrieve. </param>
        /// <param name="projectId"> The ID of the project to get snippets from. </param>
        /// <returns> A <see cref="RequestResult{ProjectSnippet}" /> representing the results of the request. </returns>
        public async Task<RequestResult<ProjectSnippet>> Find(uint id, uint projectId)
        {
            var request = RequestFactory.Create("projects/{projectId}/snippets/{id}", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("id", id);

            return await request.Execute<ProjectSnippet>();
        }

        /// <summary> Gets all of the project snippets associated with a project. </summary>
        /// <param name="projectId"> The ID of the project to get snippets from. </param>
        /// <param name="page"> The page number for a paginated request. </param>
        /// <param name="resultsPerPage"> The number of results to return per request. </param>
        /// <returns> A <see cref="PaginatedResult{ProjectSnippet}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<ProjectSnippet>> GetAll(uint projectId, uint page = Config.DefaultPage,
            uint resultsPerPage = Config.DefaultResultsPerPage)
        {
            if (page < Config.DefaultPage)
                throw new ArgumentOutOfRangeException(nameof(page), page,
                    "The parameter 'page' must be greater than " + Config.DefaultPage + ".");

            if (resultsPerPage < Config.MinResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage,
                    "The parameter 'resultsPerPage' must be greater than " + Config.MinResultsPerPage + ".");

            if (resultsPerPage > Config.MaxResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage,
                    "The parameter 'resultsPerPage' must be less than " + Config.MaxResultsPerPage + ".");

            var request = RequestFactory.Create("projects/{projectId}/snippets", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameter("page", page);
            request.AddParameter("per_page", resultsPerPage);

            return await request.ExecutePaginated<ProjectSnippet>();
        }

        /// <summary> Gets a snippet's content by its ID and the project ID it is associated with. </summary>
        /// <param name="id"> The ID of the snippet. </param>
        /// <param name="projectId"> The ID of the project to get the snippet from. </param>
        /// <returns> A <see cref="RequestResult{String}" /> representing the results of the request. </returns>
        public async Task<RequestResult<string>> GetContent(uint id, uint projectId)
        {
            var request = RequestFactory.Create("projects/{projectId}/snippets/{id}/raw", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("id", id);

            return await request.ExecuteContent();
        }

        /// <summary> Updates a project snippet associated with the provided project ID. </summary>
        /// <param name="id"> The ID of the snippet to update. </param>
        /// <param name="projectId"> The ID of the project the snippet is attached to. </param>
        /// <param name="title"> The snippet's title. </param>
        /// <param name="fileName"> The snippet's file name. </param>
        /// <param name="code"> The code for this snippet. </param>
        /// <param name="visibilityLevel"> The visibility level for this snippet. </param>
        /// <returns> A <see cref="RequestResult{ProjectSnippet}" /> representing the results of the request. </returns>
        public async Task<RequestResult<ProjectSnippet>> Update(uint id, uint projectId, string title = null,
            string fileName = null, string code = null, VisibilityLevel? visibilityLevel = null)
        {
            var request = RequestFactory.Create("projects/{projectId}/snippets/{id}", Method.Put);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("id", id);
            request.AddParameterIfNotNull("title", title);
            request.AddParameterIfNotNull("file_name", fileName);
            request.AddParameterIfNotNull("code", code);
            request.AddParameterIfNotNull("visibility_level", visibilityLevel);

            return await request.Execute<ProjectSnippet>();
        }
    }
}