// ReSharper disable UnusedMember.Global

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.RequestModels;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab License Template access in a repository pattern. </summary>
    public class LicenseRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="LicenseRepository" /> instance. </summary>
        /// <param name="restExecutor"> An instance of <see cref="IRequestExecutor" /> to use for this repository. </param>
        public LicenseRepository(IRequestExecutor restExecutor) : base(restExecutor) { }

        /// <summary> Gets a license matching the specified key. </summary>
        /// <param name="key"> The key for the desired license. </param>
        /// <param name="project"> The project name to replace references in the license with. </param>
        /// <param name="fullName"> The full name of the copyright holder to replace references in the license with. </param>
        /// <returns> A <see cref="RequestResult{License}" /> representing the results of the request. </returns>
        public RequestResult<License> Get(string key, string project = null, string fullName = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var request = new GetLicenseRequest(key, project, fullName);

            var result = RequestExecutor.Execute<License>(request);

            return new RequestResult<License>(result);
        }

        /// <summary> Gets a license matching the specified key. </summary>
        /// <param name="key"> The key for the desired license. </param>
        /// <param name="project"> The project name to replace references in the license with. </param>
        /// <param name="fullName"> The full name of the copyright holder to replace references in the license with. </param>
        /// <returns> A <see cref="RequestResult{License}" /> representing the results of the request. </returns>
        public async Task<RequestResult<License>> GetAsync(string key, string project = null, string fullName = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var request = new GetLicenseRequest(key, project, fullName);

            var result = await RequestExecutor.ExecuteAsync<License>(request);

            return new RequestResult<License>(result);
        }

        /// <summary> Gets all license templates. </summary>
        /// <param name="popular"> Whether or not to only return popular results. </param>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{License}" /> representing the results of the
        ///     request.
        /// </returns>
        public RequestResult<List<License>> GetAll(bool? popular = null)
        {
            var request = new GetLicensesRequest(popular);

            var result = RequestExecutor.Execute<List<License>>(request);

            return new RequestResult<List<License>>(result);
        }

        /// <summary> Gets all license templates. </summary>
        /// <param name="popular"> Whether or not to only return popular results. </param>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{License}" /> representing the results of the
        ///     request.
        /// </returns>
        public async Task<RequestResult<List<License>>> GetAllAsync(bool? popular = null)
        {
            var request = new GetLicensesRequest(popular);

            var result = await RequestExecutor.ExecuteAsync<List<License>>(request);

            return new RequestResult<List<License>>(result);
        }
    }
}