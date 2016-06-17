using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitLab.NET.Abstractions;
using GitLab.NET.ResponseModels;

namespace GitLab.NET.Repositories
{
    /// <summary> Provides GitLab License Template access in a repository pattern. </summary>
    public class LicenseRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="LicenseRepository" /> instance. </summary>
        /// <param name="requestFactory"> An instance of <see cref="IRequestFactory" /> to use for this repository. </param>
        public LicenseRepository(IRequestFactory requestFactory) : base(requestFactory) { }

        /// <summary> Finds a license template matching the specified key. </summary>
        /// <param name="key"> The key for the desired license. </param>
        /// <param name="project"> The project name to replace references in the license with. </param>
        /// <param name="fullName"> The full name of the copyright holder to replace references in the license with. </param>
        /// <returns> A <see cref="RequestResult{License}" /> representing the results of the request. </returns>
        public async Task<RequestResult<License>> Find(string key, string project = null, string fullName = null)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            var request = RequestFactory.Create("licenses/{key}", Method.Get);

            request.AddUrlSegment("key", key);
            request.AddParameterIfNotNull("project", project);
            request.AddParameterIfNotNull("fullname", fullName);

            return await request.Execute<License>();
        }

        /// <summary> Gets all license templates. </summary>
        /// <param name="popular"> Whether or not to only return popular results. </param>
        /// <returns>
        ///     A <see cref="RequestResult{T}" /> containing a <see cref="List{License}" /> representing the results of the
        ///     request.
        /// </returns>
        public async Task<RequestResult<List<License>>> GetAll(bool? popular = null)
        {
            var request = RequestFactory.Create("licenses", Method.Get);

            request.AddParameterIfNotNull("popular", popular);

            return await request.Execute<List<License>>();
        }
    }
}