using System;

namespace GitLab.NET
{
    /// <summary> Base implementation of a repository. </summary>
    public abstract class RepositoryBase
    {
        /// <summary> The <see cref="IRequestExecutor" /> instance for this class. </summary>
        protected readonly IRequestExecutor RequestExecutor;

        /// <summary> Base constructor for a <see cref="RepositoryBase" /> class. </summary>
        /// <param name="restExecutor"> </param>
        protected RepositoryBase(IRequestExecutor restExecutor)
        {
            if (restExecutor == null)
                throw new ArgumentNullException(nameof(restExecutor));

            RequestExecutor = restExecutor;
        }
    }
}