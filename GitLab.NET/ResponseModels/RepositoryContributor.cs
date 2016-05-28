// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedMember.Global

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about a repository contributor. </summary>
    public class RepositoryContributor
    {
        /// <summary> The contributor's name. </summary>
        public string Name { get; set; }

        /// <summary> The contributor's email address. </summary>
        public string Email { get; set; }

        /// <summary> The number of commits this contributor has made to the repository. </summary>
        public uint Commits { get; set; }

        /// <summary> The number of additions this contributor has made to the repository. </summary>
        public uint Additions { get; set; }

        /// <summary> The number of deletions this contributor has made to the repository. </summary>
        public uint Deletions { get; set; }
    }
}