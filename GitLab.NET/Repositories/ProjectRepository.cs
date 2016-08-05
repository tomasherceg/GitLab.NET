using GitLab.NET;
using GitLab.NET.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories {
    /// <summary> Provides GitLab Projects access in a repository pattern. </summary>
    public class ProjectRepository : RepositoryBase {
        /// <summary> Creates a new <see cref="ProjectRepository" /> instance. </summary>
        /// <param name="requestFactory"> An instance of <see cref="IRequestFactory" /> to use for this repository. </param>
        public ProjectRepository(IRequestFactory requestFactory) : base(requestFactory) { }

        /// <summary> Gets all projects. </summary>
        /// <param name="page"> The page number for a paginated request. </param>
        /// <param name="resultsPerPage"> The number of results to return per request. </param>
        /// <returns> A <see cref="PaginatedResult{Project}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<Project>> GetAll(uint page = Config.DefaultPage, uint resultsPerPage = Config.DefaultResultsPerPage) {
            if(page < Config.DefaultPage)
                throw new ArgumentOutOfRangeException(nameof(page), page, "The parameter 'page' must be greater than " + Config.DefaultPage + ".");

            if(resultsPerPage < Config.MinResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage, "The parameter 'resultsPerPage' must be greater than " + Config.MinResultsPerPage + ".");

            if(resultsPerPage > Config.MaxResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage, "The parameter 'resultsPerPage' must be less than " + Config.MaxResultsPerPage + ".");

            var request = RequestFactory.Create("projects", Method.Get);

            request.AddParameter("all", "all");
            request.AddParameter("page", page);
            request.AddParameter("per_page", resultsPerPage);

            return await request.ExecutePaginated<Project>();
        }

        /// <summary> Gets accessible projects. </summary>
        /// <param name="page"> The page number for a paginated request. </param>
        /// <param name="resultsPerPage"> The number of results to return per request. </param>
        /// <returns> A <see cref="PaginatedResult{Project}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<Project>> Accessible(uint page = Config.DefaultPage, uint resultsPerPage = Config.DefaultResultsPerPage) {
            if(page < Config.DefaultPage)
                throw new ArgumentOutOfRangeException(nameof(page), page, "The parameter 'page' must be greater than " + Config.DefaultPage + ".");

            if(resultsPerPage < Config.MinResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage, "The parameter 'resultsPerPage' must be greater than " + Config.MinResultsPerPage + ".");

            if(resultsPerPage > Config.MaxResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage, "The parameter 'resultsPerPage' must be less than " + Config.MaxResultsPerPage + ".");

            var request = RequestFactory.Create("projects", Method.Get);

            request.AddParameter("page", page);
            request.AddParameter("per_page", resultsPerPage);

            return await request.ExecutePaginated<Project>();
        }

        /// <summary> Gets a project by its ID. </summary>
        /// <param name="id"> The ID of the project. </param>
        /// <returns> A <see cref="RequestResult{Project}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Project>> Find(uint id) {
            if(id < 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            var request = RequestFactory.Create("projects/{id}", Method.Get);

            request.AddUrlSegment("id", id);

            return await request.Execute<Project>();
        }
    }
}