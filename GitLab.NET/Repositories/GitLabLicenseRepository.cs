using System.Threading.Tasks;
using GitLab.NET.Abstractions;
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
        public async Task<RequestResult<GitLabLicense>> Get()
        {
            var request = RequestFactory.Create("license", Method.Get);

            return await request.ExecuteAsync<GitLabLicense>();
        }
    }
}