using System;
using GitLab.NET.Abstractions;

namespace GitLab.NET.Repositories
{
    /// <summary> Base implementation of a repository. </summary>
    public abstract class RepositoryBase
    {
        /// <summary> The <see cref="IRequestFactory" /> instance for this class. </summary>
        protected readonly IRequestFactory RequestFactory;

        /// <summary> Base constructor for a <see cref="RepositoryBase" /> class. </summary>
        /// <param name="requestFactory"> An instance of <see cref="IRequestFactory" /> to use for this repository. </param>
        protected RepositoryBase(IRequestFactory requestFactory)
        {
            if (requestFactory == null)
                throw new ArgumentNullException(nameof(requestFactory));

            RequestFactory = requestFactory;
        }
    }
}