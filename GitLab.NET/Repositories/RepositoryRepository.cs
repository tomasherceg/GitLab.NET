using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab Repository access in a repository pattern. </summary>
    public class RepositoryRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="RepositoryRepository" /> instance. </summary>
        /// <param name="requestFactory"> An instance of <see cref="IRequestFactory" /> to use for this repository. </param>
        public RepositoryRepository(IRequestFactory requestFactory) : base(requestFactory) { }

        /// <summary> Compares two branches or tags. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="from"> The branch or tag to compare from. </param>
        /// <param name="to"> The branch or tag to compare to. </param>
        /// <returns> A <see cref="RequestResult{RepositoryComparison}" /> representing the results of the request. </returns>
        public async Task<RequestResult<RepositoryComparison>> Compare(uint projectId, string from, string to)
        {
            if (from == null)
                throw new ArgumentNullException(nameof(from));

            if (to == null)
                throw new ArgumentNullException(nameof(to));

            var request = RequestFactory.Create("projects/{projectId}/repository/compare", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameter("from", from);
            request.AddParameter("to", to);

            return await request.Execute<RepositoryComparison>();
        }

        /// <summary> Gets an archive of the repository. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="sha"> The commit sha to download. </param>
        /// <returns> A <see cref="RequestResult{T}" /> representing the results of the request. </returns>
        public async Task<RequestResult<byte[]>> GetArchive(uint projectId, string sha = null)
        {
            var request = RequestFactory.Create("projects/{projectId}/repository/archive", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameterIfNotNull("sha", sha);

            return await request.ExecuteBytes();
        }

        /// <summary> Gets the contents of a blob file. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="sha"> The sha of the blob. </param>
        /// <returns> A <see cref="RequestResult{T}" /> representing the results of the request. </returns>
        public async Task<RequestResult<byte[]>> GetBlobContent(uint projectId, string sha)
        {
            if (sha == null)
                throw new ArgumentNullException(nameof(sha));

            var request = RequestFactory.Create("projects/{projectId}/repository/raw_blobs/{sha}", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("sha", sha);

            return await request.ExecuteBytes();
        }

        /// <summary> Gets the contributors for the repository. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{RepositoryContributor}" /> representing the
        ///     results of the request.
        /// </returns>
        public async Task<RequestResult<List<RepositoryContributor>>> GetContributors(uint projectId)
        {
            var request = RequestFactory.Create("projects/{projectId}/repository/contributors", Method.Get);

            request.AddUrlSegment("projectId", projectId);

            return await request.Execute<List<RepositoryContributor>>();
        }

        /// <summary> Gets the contents of a file. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="sha"> The sha of the file. </param>
        /// <param name="filePath"> The path of the file. </param>
        /// <returns> A <see cref="RequestResult{T}" /> representing the results of the request. </returns>
        public async Task<RequestResult<byte[]>> GetFileContent(uint projectId, string sha, string filePath)
        {
            if (sha == null)
                throw new ArgumentNullException(nameof(sha));

            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath));

            var request = RequestFactory.Create("projects/{projectId}/repository/blobs/{sha}", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddUrlSegment("sha", sha);
            request.AddParameter("filepath", filePath);

            return await request.ExecuteBytes();
        }

        /// <summary> Gets a list of repository files and directories in a project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="path"> The path inside the repository. </param>
        /// <param name="refName"> The name of a repository branch or tag. </param>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{RepositoryTreeItem}" /> representing the
        ///     results of the request.
        /// </returns>
        public async Task<RequestResult<List<RepositoryTreeItem>>> GetTree(uint projectId, string path = null, string refName = null)
        {
            var request = RequestFactory.Create("projects/{projectId}/repository/tree", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameterIfNotNull("path", path);
            request.AddParameterIfNotNull("ref_name", refName);

            return await request.Execute<List<RepositoryTreeItem>>();
        }
    }
}