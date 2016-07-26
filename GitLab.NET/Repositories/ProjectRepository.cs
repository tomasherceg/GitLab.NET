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

        public async Task<PaginatedResult<Project>> GetAll(uint page = Config.DefaultPage, uint resultsPerPage = Config.DefaultResultsPerPage) {
            if(page < Config.DefaultPage)
                throw new ArgumentOutOfRangeException(nameof(page), page, "The parameter 'page' must be greater than " + Config.DefaultPage + ".");

            if(resultsPerPage < Config.MinResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage, "The parameter 'resultsPerPage' must be greater than " + Config.MinResultsPerPage + ".");

            if(resultsPerPage > Config.MaxResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage, "The parameter 'resultsPerPage' must be less than " + Config.MaxResultsPerPage + ".");

            var request = RequestFactory.Create("projects/all", Method.Get);

            request.AddParameter("page", page);
            request.AddParameter("per_page", resultsPerPage);

            return await request.ExecutePaginated<Project>();
        }

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

        public async Task<RequestResult<Project>> Find(uint id) {
            if(id < 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            var request = RequestFactory.Create("projects", Method.Get);

            request.AddUrlSegment("id", id);

            return await request.Execute<Project>();
        }
    }
}