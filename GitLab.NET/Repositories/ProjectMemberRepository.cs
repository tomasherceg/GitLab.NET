using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    public class ProjectMemberRepository : RepositoryBase
    {
        
        public ProjectMemberRepository(IRequestFactory requestFactory) : base(requestFactory)
        {
        }

        /// <summary> Gets a list of project members viewable by the authenticated user. </summary>
        /// <param name="projectId"> The ID or URL-encoded path of the project owned by the authenticated user </param>
        /// <param name="page"> The page number for a paginated request. </param>
        /// <param name="resultsPerPage"> The number of results to return per request. </param>
        /// <returns> A <see cref="PaginatedResult{ProjectMember}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<Member>> GetAll(string projectId, uint page = Config.DefaultPage,
            uint resultsPerPage = Config.DefaultResultsPerPage)
        {
            if (string.IsNullOrEmpty(projectId))
                throw new ArgumentNullException(nameof(projectId),
                    "The 'projectId' parameter is required.");

            if (page < Config.DefaultPage)
                throw new ArgumentOutOfRangeException(nameof(page), page,
                    "The parameter 'page' must be greater than " + Config.DefaultPage + ".");

            if (resultsPerPage < Config.MinResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage,
                    "The parameter 'resultsPerPage' must be greater than " + Config.MinResultsPerPage + ".");

            if (resultsPerPage > Config.MaxResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage,
                    "The parameter 'resultsPerPage' must be less than " + Config.MaxResultsPerPage + ".");

            var request = RequestFactory.Create("projects/{projectId}/members", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameter("page", page);
            request.AddParameter("per_page", resultsPerPage);

            return await request.ExecutePaginated<Member>();
        }

        /// <summary> Adds a member to a project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="user_id"> The ID of the user. </param>
        /// <param name="access_level"> The access level of the member. </param>
        /// <param name="expires_at"> The expiration date of the member. </param>
        /// <returns> A <see cref="RequestResult{Member}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Member>> Create(string projectId, uint user_id, AccessLevel access_level, DateTime? expires_at)
        {
            if (string.IsNullOrEmpty(projectId))
                throw new ArgumentNullException(nameof(projectId),
                    "The 'projectId' parameter is required.");

            var request = RequestFactory.Create("projects/{projectId}/members", Method.Post);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameter("user_id", user_id);
            request.AddParameter("access_level", (int)access_level);
            request.AddParameterIfNotNull("expires_at", expires_at);

            return await request.Execute<Member>();
        }

        /// <summary> Edits a member of a project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="user_id"> The ID of the user. </param>
        /// <param name="access_level"> The access level of the member. </param>
        /// <param name="expires_at"> The expiration date of the member. </param>
        /// <returns> A <see cref="RequestResult{Member}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Member>> Update(string projectId, uint user_id, AccessLevel access_level, DateTime? expires_at)
        {
            if (string.IsNullOrEmpty(projectId))
                throw new ArgumentNullException(nameof(projectId),
                    "The 'projectId' parameter is required.");

            var request = RequestFactory.Create("projects/{projectId}/members", Method.Put);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameter("user_id", user_id);
            request.AddParameter("access_level", (int)access_level);
            request.AddParameterIfNotNull("expires_at", expires_at);

            return await request.Execute<Member>();
        }

        /// <summary> Removes a member from a project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="userId"> The ID of the user. </param>
        /// <returns> A <see cref="RequestResult{Member}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Member>> Delete(string projectId, uint userId)
        {
            if (string.IsNullOrEmpty(projectId))
                throw new ArgumentNullException(nameof(projectId),
                    "The 'projectId' parameter is required.");

            var request = RequestFactory.Create("projects/{projectId}/members/{userId}", Method.Delete);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("userId", userId);

            return await request.Execute<Member>();
        }

    }
}
