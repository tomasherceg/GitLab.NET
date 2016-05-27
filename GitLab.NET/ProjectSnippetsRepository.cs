// ReSharper disable UnusedMember.Global
namespace GitLab.NET
{
    /// <summary> Provides GitLab Project Snippets access in a repository pattern. </summary>
    public class ProjectSnippetsRepository : RepositoryBase
    {
        /// <summary> Creates a new <see cref="ProjectSnippetsRepository" /> instance. </summary>
        /// <param name="restExecutor"> An instance of <see cref="IRequestExecutor" /> to use for this repository. </param>
        public ProjectSnippetsRepository(IRequestExecutor restExecutor) : base(restExecutor) { }
    }
}