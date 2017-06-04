using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    public class GroupMemberRepository : RepositoryBase
    {

        public GroupMemberRepository(IRequestFactory requestFactory) : base(requestFactory)
        {
        }

        /// <summary> Gets a list of group members viewable by the authenticated user. </summary>
        /// <param name="groupId"> The ID or URL-encoded path of the group owned by the authenticated user </param>
        /// <param name="page"> The page number for a paginated request. </param>
        /// <param name="resultsPerPage"> The number of results to return per request. </param>
        /// <returns> A <see cref="PaginatedResult{Member}" /> representing the results of the request. </returns>
        public async Task<PaginatedResult<Member>> GetAll(string groupId, uint page = Config.DefaultPage,
            uint resultsPerPage = Config.DefaultResultsPerPage)
        {
            if (string.IsNullOrEmpty(groupId))
                throw new ArgumentNullException(nameof(groupId),
                    "The 'groupId' parameter is required.");

            if (page < Config.DefaultPage)
                throw new ArgumentOutOfRangeException(nameof(page), page,
                    "The parameter 'page' must be greater than " + Config.DefaultPage + ".");

            if (resultsPerPage < Config.MinResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage,
                    "The parameter 'resultsPerPage' must be greater than " + Config.MinResultsPerPage + ".");

            if (resultsPerPage > Config.MaxResultsPerPage)
                throw new ArgumentOutOfRangeException(nameof(resultsPerPage), resultsPerPage,
                    "The parameter 'resultsPerPage' must be less than " + Config.MaxResultsPerPage + ".");

            var request = RequestFactory.Create("groups/{groupId}/members", Method.Get);

            request.AddUrlSegment("groupId", groupId);
            request.AddParameter("page", page);
            request.AddParameter("per_page", resultsPerPage);

            return await request.ExecutePaginated<Member>();
        }

        /// <summary> Adds a member to a group. </summary>
        /// <param name="groupId"> The ID of the group. </param>
        /// <param name="user_id"> The ID of the user. </param>
        /// <param name="access_level"> The access level of the member. </param>
        /// <param name="expires_at"> The expiration date of the member. </param>
        /// <returns> A <see cref="RequestResult{Member}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Member>> Create(string groupId, uint user_id, AccessLevel access_level, DateTime? expires_at)
        {
            if (string.IsNullOrEmpty(groupId))
                throw new ArgumentNullException(nameof(groupId),
                    "The 'groupId' parameter is required.");

            var request = RequestFactory.Create("groups/{groupId}/members", Method.Post);

            request.AddUrlSegment("groupId", groupId);
            request.AddParameter("user_id", user_id);
            request.AddParameter("access_level", (int)access_level);
            request.AddParameterIfNotNull("expires_at", expires_at);

            return await request.Execute<Member>();
        }

        /// <summary> Edits a member of a group. </summary>
        /// <param name="groupId"> The ID of the group. </param>
        /// <param name="user_id"> The ID of the user. </param>
        /// <param name="access_level"> The access level of the member. </param>
        /// <param name="expires_at"> The expiration date of the member. </param>
        /// <returns> A <see cref="RequestResult{Member}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Member>> Update(string groupId, uint user_id, AccessLevel access_level, DateTime? expires_at)
        {
            if (string.IsNullOrEmpty(groupId))
                throw new ArgumentNullException(nameof(groupId),
                    "The 'groupId' parameter is required.");

            var request = RequestFactory.Create("groups/{groupId}/members", Method.Put);

            request.AddUrlSegment("groupId", groupId);
            request.AddParameter("user_id", user_id);
            request.AddParameter("access_level", (int)access_level);
            request.AddParameterIfNotNull("expires_at", expires_at);

            return await request.Execute<Member>();
        }

        /// <summary> Removes a member from a group. </summary>
        /// <param name="groupId"> The ID of the group. </param>
        /// <param name="userId"> The ID of the user. </param>
        /// <returns> A <see cref="RequestResult{Member}" /> representing the results of the request. </returns>
        public async Task<RequestResult<Member>> Delete(string groupId, uint userId)
        {
            if (string.IsNullOrEmpty(groupId))
                throw new ArgumentNullException(nameof(groupId),
                    "The 'groupId' parameter is required.");

            var request = RequestFactory.Create("groups/{groupId}/members/{userId}", Method.Delete);

            request.AddUrlSegment("groupId", groupId);
            request.AddUrlSegment("userId", userId);

            return await request.Execute<Member>();
        }

    }
}