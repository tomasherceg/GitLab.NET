using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab Projects access in a repository pattern. </summary>
    public class ProjectRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="ProjectRepository" /> instance. </summary>
        /// <param name="requestFactory"> An instance of <see cref="IRequestFactory" /> to use for this repository. </param>
        public ProjectRepository(IRequestFactory requestFactory) : base(requestFactory)
        {
        }

        /// <summary> Gets all projects. </summary>
        /// <param name="page"> The page number for a paginated request. </param>
        /// <param name="resultsPerPage"> The number of results to return per request. </param>
        /// <returns> A <see cref="PaginatedResult{Project}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<Project>> GetAll(uint page = Config.DefaultPage,
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

            var request = RequestFactory.Create("projects/all", Method.Get);

            request.AddParameter("page", page);
            request.AddParameter("per_page", resultsPerPage);

            return await request.ExecutePaginated<Project>();
        }

        /// <summary> Gets accessible projects. </summary>
        /// <param name="page"> The page number for a paginated request. </param>
        /// <param name="resultsPerPage"> The number of results to return per request. </param>
        /// <returns> A <see cref="PaginatedResult{Project}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<Project>> Accessible(uint page = Config.DefaultPage,
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

            var request = RequestFactory.Create("projects", Method.Get);

            request.AddParameter("page", page);
            request.AddParameter("per_page", resultsPerPage);

            return await request.ExecutePaginated<Project>();
        }

        /// <summary> Gets a project by its ID. </summary>
        /// <param name="id"> The ID of the project. </param>
        /// <returns> A <see cref="RequestResult{Project}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Project>> Find(uint id)
        {
            var request = RequestFactory.Create("projects/{id}", Method.Get);

            request.AddUrlSegment("id", id);

            return await request.Execute<Project>();
        }

        /// <summary> Creates a new project. </summary>
        /// <param name="name"> The name of the new project. Equals path if not provided. </param>
        /// <param name="path"> Repository name for new project. Generated based on name if not provided (generated lowercased with dashes). </param>
        /// <param name="namespace_id"> Namespace for the new project (defaults to the current user's namespace) </param>
        /// <param name="default_branch"> master by default </param>
        /// <param name="description"> Short project description </param>
        /// <param name="issues_enabled"> Enable issues for this project </param>
        /// <param name="merge_requests_enabled"> Enable merge requests for this project </param>
        /// <param name="jobs_enabled"> Enable jobs for this project </param>
        /// <param name="wiki_enabled"> Enable wiki for this project </param>
        /// <param name="snippets_enabled"> Enable snippets for this project </param>
        /// <param name="container_registry_enabled"> Enable container registry for this project </param>
        /// <param name="shared_runners_enabled"> Enable shared runners for this project </param>
        /// <param name="visibility"> See project visibility level </param>
        /// <param name="import_url"> URL to import repository from </param>
        /// <param name="public_jobs"> If true, jobs can be viewed by non-project-members </param>
        /// <param name="only_allow_merge_if_pipeline_succeeds"> Set whether merge requests can only be merged with successful jobs </param>
        /// <param name="only_allow_merge_if_all_discussions_are_resolved"> Set whether merge requests can only be merged when all the discussions are resolved </param>
        /// <param name="lfs_enabled"> Enable LFS </param>
        /// <param name="request_access_enabled"> Allow users to request member access </param>
        /// <param name="repository_storage"> Which storage shard the repository is on. Available only to admins </param>
        /// <param name="approvals_before_merge"> How many approvers should approve merge request by default </param>
        /// <returns> A <see cref="RequestResult{Project}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Project>> Create(
            string name,
            string path,
            uint? namespace_id = null,
            string default_branch = null,
            string description = null,
            bool? issues_enabled = null,
            bool? merge_requests_enabled = null,
            bool? jobs_enabled = null,
            bool? wiki_enabled = null,
            bool? snippets_enabled = null,
            bool? container_registry_enabled = null,
            bool? shared_runners_enabled = null,
            VisibilityLevel? visibility = null,
            string import_url = null,
            bool? public_jobs = null,
            bool? only_allow_merge_if_pipeline_succeeds = null,
            bool? only_allow_merge_if_all_discussions_are_resolved = null,
            bool? lfs_enabled = null,
            bool? request_access_enabled = null,
            string repository_storage = null,
            int? approvals_before_merge = 0
        )
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (path == null)
                throw new ArgumentNullException(nameof(path));
            
            var request = RequestFactory.Create("projects", Method.Post);

            request.AddParameter("name", name);
            request.AddParameter("path", path);
            request.AddParameterIfNotNull("namespace_id", namespace_id);
            request.AddParameterIfNotNull("default_branch", default_branch);
            request.AddParameterIfNotNull("description", description);
            request.AddParameterIfNotNull("issues_enabled", issues_enabled);
            request.AddParameterIfNotNull("merge_requests_enabled", merge_requests_enabled);
            request.AddParameterIfNotNull("jobs_enabled", jobs_enabled);
            request.AddParameterIfNotNull("wiki_enabled", wiki_enabled);
            request.AddParameterIfNotNull("snippets_enabled", snippets_enabled);
            request.AddParameterIfNotNull("container_registry_enabled", container_registry_enabled);
            request.AddParameterIfNotNull("shared_runners_enabled", shared_runners_enabled);
            request.AddParameterIfNotNull("visibility", visibility);
            request.AddParameterIfNotNull("import_url", import_url);
            request.AddParameterIfNotNull("public_jobs", public_jobs);
            request.AddParameterIfNotNull("only_allow_merge_if_pipeline_succeeds", only_allow_merge_if_pipeline_succeeds);
            request.AddParameterIfNotNull("only_allow_merge_if_all_discussions_are_resolved", only_allow_merge_if_all_discussions_are_resolved);
            request.AddParameterIfNotNull("lfs_enabled", lfs_enabled);
            request.AddParameterIfNotNull("request_access_enabled", request_access_enabled);
            request.AddParameterIfNotNull("repository_storage", repository_storage);
            request.AddParameterIfNotNull("approvals_before_merge", approvals_before_merge);

            return await request.Execute<Project>();
        }

        /// <summary> Search for projects by name which are accessible to the authenticated user. This endpoint can be accessed without authentication if the project is publicly accessible. </summary>
        /// <param name="searchQuery"> A string contained in the project name </param>
        /// <param name="page"> The page number for a paginated request. </param>
        /// <param name="resultsPerPage"> The number of results to return per request. </param>
        /// <returns> A <see cref="PaginatedResult{Project}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<Project>> Search(string searchQuery, string order_by = null, string sort = null, uint page = Config.DefaultPage,
            uint resultsPerPage = Config.DefaultResultsPerPage)
        {
            if (searchQuery == null)
                throw new ArgumentNullException(nameof(searchQuery));

            if (page < Config.DefaultPage)
                throw new ArgumentOutOfRangeException(nameof(page), page,
                    "The parameter 'page' must be greater than " + Config.DefaultPage + ".");

            if (resultsPerPage < Config.MinResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage,
                    "The parameter 'resultsPerPage' must be greater than " + Config.MinResultsPerPage + ".");

            if (resultsPerPage > Config.MaxResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage,
                    "The parameter 'resultsPerPage' must be less than " + Config.MaxResultsPerPage + ".");

            var request = RequestFactory.Create("projects/search/{searchQuery}", Method.Get);

            request.AddUrlSegment("searchQuery", searchQuery);
            request.AddParameter("page", page);
            request.AddParameter("per_page", resultsPerPage);
            request.AddParameterIfNotNull("order_by", order_by);
            request.AddParameterIfNotNull("sort", sort);

            return await request.ExecutePaginated<Project>();
        }
    }
}