using System;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab File access in a repository pattern. </summary>
    public class FileRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="FileRepository" /> instance. </summary>
        /// <param name="requestFactory"> An instance of <see cref="IRequestFactory" /> to use for this repository. </param>
        public FileRepository(IRequestFactory requestFactory) : base(requestFactory) { }

        /// <summary> Creates a new file. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="filePath"> The path for the new file. </param>
        /// <param name="branchName"> The branch name for the new file. </param>
        /// <param name="content"> The new file's contents. </param>
        /// <param name="commitMessage"> The commit message to use for the commit created by this operation. </param>
        /// <param name="encoding"> The encoding of the content field. </param>
        /// <returns> A <see cref="RequestResult{RepositoryFile}" /> representing the results of the request. </returns>
        public async Task<RequestResult<RepositoryFile>> Create(uint projectId, string filePath, string branchName, string content, string commitMessage, string encoding = null)
        {
            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath));

            if (branchName == null)
                throw new ArgumentNullException(nameof(branchName));

            if (content == null)
                throw new ArgumentNullException(nameof(content));

            if (commitMessage == null)
                throw new ArgumentNullException(nameof(commitMessage));

            var request = RequestFactory.Create("projects/{projectId}/repository/files", Method.Post);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameter("file_path", filePath);
            request.AddParameter("branch_name", branchName);
            request.AddParameter("content", content);
            request.AddParameter("commit_message", commitMessage);
            request.AddParameterIfNotNull("encoding", encoding);

            return await request.Execute<RepositoryFile>();
        }

        /// <summary> Deletes a file. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="filePath"> The path of the file to delete. </param>
        /// <param name="branchName"> The name of the branch to delete the file from. </param>
        /// <param name="commitMessage"> The commit message to use for this operation. </param>
        /// <returns> A <see cref="RequestResult{RepositoryFile}" /> representing the results of this request. </returns>
        public async Task<RequestResult<RepositoryFile>> Delete(uint projectId, string filePath, string branchName, string commitMessage)
        {
            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath));

            if (branchName == null)
                throw new ArgumentNullException(nameof(branchName));

            if (commitMessage == null)
                throw new ArgumentNullException(nameof(commitMessage));

            var request = RequestFactory.Create("projects/{projectId}/repository/files", Method.Delete);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameter("file_path", filePath);
            request.AddParameter("branch_name", branchName);
            request.AddParameter("commit_message", commitMessage);

            return await request.Execute<RepositoryFile>();
        }

        /// <summary> Finds a file by its path. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="filePath"> The path of the file. </param>
        /// <param name="refName"> The branch or tag name for the file. </param>
        /// <returns> A <see cref="RequestResult{RepositoryFile}" /> representing the results of the request. </returns>
        public async Task<RequestResult<RepositoryFile>> Find(uint projectId, string filePath, string refName)
        {
            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath));

            if (refName == null)
                throw new ArgumentNullException(nameof(refName));

            var request = RequestFactory.Create("projects/{projectId}/repository/files", Method.Get);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameter("file_path", filePath);
            request.AddParameter("ref", refName);

            return await request.Execute<RepositoryFile>();
        }

        /// <summary> Updates a file. </summary>
        /// <param name="projectId"> The ID of the project. </param>
        /// <param name="filePath"> The path for the file. </param>
        /// <param name="branchName"> The branch name for the file. </param>
        /// <param name="content"> The file's contents. </param>
        /// <param name="commitMessage"> The commit message to use for the commit created by this operation. </param>
        /// <param name="encoding"> The encoding of the content field. </param>
        /// <returns> A <see cref="RequestResult{RepositoryFile}" /> representing the results of the request. </returns>
        public async Task<RequestResult<RepositoryFile>> Update(uint projectId, string filePath, string branchName, string content, string commitMessage, string encoding = null)
        {
            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath));

            if (branchName == null)
                throw new ArgumentNullException(nameof(branchName));

            if (content == null)
                throw new ArgumentNullException(nameof(content));

            if (commitMessage == null)
                throw new ArgumentNullException(nameof(commitMessage));

            var request = RequestFactory.Create("projects/{projectId}/repository/files", Method.Put);

            request.AddUrlSegment("projectId", projectId);
            request.AddParameter("file_path", filePath);
            request.AddParameter("branch_name", branchName);
            request.AddParameter("content", content);
            request.AddParameter("commit_message", commitMessage);
            request.AddParameterIfNotNull("encoding", encoding);

            return await request.Execute<RepositoryFile>();
        }
    }
}