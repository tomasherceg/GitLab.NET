// ReSharper disable UnusedMember.Global

using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.RequestModels;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab User access in a repository pattern. </summary>
    public class GitLabLicenseRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="GitLabLicenseRepository" /> instance. </summary>
        /// <param name="requestFactory"> An instance of <see cref="IRequestFactory" /> to use for this repository. </param>
        public GitLabLicenseRepository(IRequestFactory requestFactory) : base(requestFactory) { }

        /// <summary> Gets information about the license for the server's GitLab installation. </summary>
        /// <returns> A <see cref="RequestResult{GitLabLicense}" /> representing the results of the request. </returns>
        public RequestResult<GitLabLicense> Get()
        {
            var request = new GetGitLabLicenseRequest();

            var result = RequestExecutor.Execute<GitLabLicense>(request);

            return new RequestResult<GitLabLicense>(result);
        }

        /// <summary> Gets information about the license for the server's GitLab installation. </summary>
        /// <returns> A <see cref="RequestResult{GitLabLicense}" /> representing the results of the request. </returns>
        public async Task<RequestResult<GitLabLicense>> GetAsync()
        {
            var request = new GetGitLabLicenseRequest();

            var result = await RequestExecutor.ExecuteAsync<GitLabLicense>(request);

            return new RequestResult<GitLabLicense>(result);
        }
    }
}