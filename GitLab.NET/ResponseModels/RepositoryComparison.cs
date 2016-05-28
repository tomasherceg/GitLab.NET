// ReSharper disable UnusedMember.Global

namespace GitLab.NET.ResponseModels
{
    /// <summary> Represents a repository comparison. </summary>
    public class RepositoryComparison
    {
        /// <summary> The last commit for the primary item in the comparison. </summary>
        public RepositoryCommit Commit { get; set; }

        /// <summary> The commits for the secondary item in the comparison. </summary>
        public RepositoryCommit[] Commits { get; set; }

        /// <summary> The diffs between the primary and secondary items in the comparison. </summary>
        public RepositoryDiff[] Diffs { get; set; }

        /// <summary> Whether or not the comparison timed out. </summary>
        public bool CompareTimeout { get; set; }

        /// <summary> Whether or not the comparison is for the same references. </summary>
        public bool CompareSameRef { get; set; }
    }
}