// ReSharper disable UnusedMember.Global

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.RequestModels;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab Repository access in a repository pattern. </summary>
    public class RepositoryRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="RepositoryRepository" /> instance. </summary>
        /// <param name="restExecutor"> An instance of <see cref="IRequestExecutor" /> to use for this repository. </param>
        public RepositoryRepository(IRequestExecutor restExecutor) : base(restExecutor) { }

        /// <summary> Compares two branches or tags. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="from"> The branch or tag to compare from. </param>
        /// <param name="to"> The branch or tag to compare to. </param>
        /// <returns> A <see cref="RequestResult{RepositoryComparison}" /> representing the results of the request. </returns>
        public RequestResult<RepositoryComparison> Compare(uint projectId, string from, string to)
        {
            if (from == null)
                throw new ArgumentNullException(nameof(from));

            if (to == null)
                throw new ArgumentNullException(nameof(to));

            var request = new CompareRepositoryRequest(projectId, from, to);

            var result = RequestExecutor.Execute<RepositoryComparison>(request);

            return new RequestResult<RepositoryComparison>(result);
        }

        /// <summary> Compares two branches or tags. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="from"> The branch or tag to compare from. </param>
        /// <param name="to"> The branch or tag to compare to. </param>
        /// <returns> A <see cref="RequestResult{RepositoryComparison}" /> representing the results of the request. </returns>
        public async Task<RequestResult<RepositoryComparison>> CompareAsync(uint projectId, string from, string to)
        {
            if (from == null)
                throw new ArgumentNullException(nameof(from));

            if (to == null)
                throw new ArgumentNullException(nameof(to));

            var request = new CompareRepositoryRequest(projectId, from, to);

            var result = await RequestExecutor.ExecuteAsync<RepositoryComparison>(request);

            return new RequestResult<RepositoryComparison>(result);
        }

        /// <summary> Gets an archive of the repository. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="sha"> The commit sha to download. </param>
        /// <returns> A <see cref="RequestResult{T}" /> representing the results of the request. </returns>
        public RequestResult<byte[]> GetArchive(uint projectId, string sha = null)
        {
            var request = new GetRepositoryFileArchiveRequest(projectId, sha);

            var result = RequestExecutor.Execute(request);

            return new RequestResult<byte[]>(result, result.RawBytes);
        }

        /// <summary> Gets an archive of the repository. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="sha"> The commit sha to download. </param>
        /// <returns> A <see cref="RequestResult{T}" /> representing the results of the request. </returns>
        public async Task<RequestResult<byte[]>> GetArchiveAsync(uint projectId, string sha = null)
        {
            var request = new GetRepositoryFileArchiveRequest(projectId, sha);

            var result = await RequestExecutor.ExecuteAsync(request);

            return new RequestResult<byte[]>(result, result.RawBytes);
        }

        /// <summary> Gets the contents of a blob file. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="sha"> The sha of the blob. </param>
        /// <returns> A <see cref="RequestResult{T}" /> representing the results of the request. </returns>
        public RequestResult<byte[]> GetBlobContent(uint projectId, string sha)
        {
            if (sha == null)
                throw new ArgumentNullException(nameof(sha));

            var request = new GetRepositoryRawBlobContentRequest(projectId, sha);

            var result = RequestExecutor.Execute(request);

            return new RequestResult<byte[]>(result, result.RawBytes);
        }

        /// <summary> Gets the contents of a blob file. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="sha"> The sha of the blob. </param>
        /// <returns> A <see cref="RequestResult{T}" /> representing the results of the request. </returns>
        public async Task<RequestResult<byte[]>> GetBlobContentAsync(uint projectId, string sha)
        {
            if (sha == null)
                throw new ArgumentNullException(nameof(sha));

            var request = new GetRepositoryRawBlobContentRequest(projectId, sha);

            var result = await RequestExecutor.ExecuteAsync(request);

            return new RequestResult<byte[]>(result, result.RawBytes);
        }

        /// <summary> Gets the contributors for the repository. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{RepositoryContributor}" /> representing the
        ///     results of the request.
        /// </returns>
        public RequestResult<List<RepositoryContributor>> GetContributors(uint projectId)
        {
            var request = new GetRepositoryContributorsRequest(projectId);

            var result = RequestExecutor.Execute<List<RepositoryContributor>>(request);

            return new RequestResult<List<RepositoryContributor>>(result);
        }

        /// <summary> Gets the contributors for the repository. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{RepositoryContributor}" /> representing the
        ///     results of the request.
        /// </returns>
        public async Task<RequestResult<List<RepositoryContributor>>> GetContributorsAsync(uint projectId)
        {
            var request = new GetRepositoryContributorsRequest(projectId);

            var result = await RequestExecutor.ExecuteAsync<List<RepositoryContributor>>(request);

            return new RequestResult<List<RepositoryContributor>>(result);
        }

        /// <summary> Gets the contents of a file. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="sha"> The sha of the file. </param>
        /// <param name="filePath"> The path of the file. </param>
        /// <returns> A <see cref="RequestResult{T}" /> representing the results of the request. </returns>
        public RequestResult<byte[]> GetFileContent(uint projectId, string sha, string filePath)
        {
            if (sha == null)
                throw new ArgumentNullException(nameof(sha));

            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath));

            var request = new GetRepositoryRawFileContentRequest(projectId, sha, filePath);

            var result = RequestExecutor.Execute(request);

            return new RequestResult<byte[]>(result, result.RawBytes);
        }

        /// <summary> Gets the contents of a file. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="sha"> The sha of the file. </param>
        /// <param name="filePath"> The path of the file. </param>
        /// <returns> A <see cref="RequestResult{T}" /> representing the results of the request. </returns>
        public async Task<RequestResult<byte[]>> GetFileContentAsync(uint projectId, string sha, string filePath)
        {
            if (sha == null)
                throw new ArgumentNullException(nameof(sha));

            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath));

            var request = new GetRepositoryRawFileContentRequest(projectId, sha, filePath);

            var result = await RequestExecutor.ExecuteAsync(request);

            return new RequestResult<byte[]>(result, result.RawBytes);
        }

        /// <summary> Gets a list of repository files and directories in a project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="path"> The path inside the repository. </param>
        /// <param name="refName"> The name of a repository branch or tag. </param>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{RepositoryTreeItem}" /> representing the
        ///     results of the request.
        /// </returns>
        public RequestResult<List<RepositoryTreeItem>> GetTree(uint projectId, string path = null, string refName = null)
        {
            var request = new GetRepositoryTreeRequest(projectId, path, refName);

            var result = RequestExecutor.Execute<List<RepositoryTreeItem>>(request);

            return new RequestResult<List<RepositoryTreeItem>>(result);
        }

        /// <summary> Gets a list of repository files and directories in a project. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="path"> The path inside the repository. </param>
        /// <param name="refName"> The name of a repository branch or tag. </param>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{RepositoryTreeItem}" /> representing the
        ///     results of the request.
        /// </returns>
        public async Task<RequestResult<List<RepositoryTreeItem>>> GetTreeAsync(uint projectId, string path = null, string refName = null)
        {
            var request = new GetRepositoryTreeRequest(projectId, path, refName);

            var result = await RequestExecutor.ExecuteAsync<List<RepositoryTreeItem>>(request);

            return new RequestResult<List<RepositoryTreeItem>>(result);
        }
    }
}