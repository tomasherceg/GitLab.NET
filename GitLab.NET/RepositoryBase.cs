using System;
using JetBrains.Annotations;

namespace GitLab.NET
{
    public abstract class RepositoryBase
    {
        protected const int MinResultsPerPage = 1;
        protected const int MaxResultsPerPage = 100;
        protected const int DefaultResultsPerPage = 20;
        protected const int DefaultPage = 1;

        protected IRestExecutor RestExecutor;

        protected RepositoryBase([NotNull] IRestExecutor restExecutor)
        {
            if (restExecutor == null)
                throw new ArgumentNullException(nameof(restExecutor));

            RestExecutor = restExecutor;
        }
    }
}