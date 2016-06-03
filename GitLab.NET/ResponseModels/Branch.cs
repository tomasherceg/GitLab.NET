// ReSharper disable UnusedMember.Global

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about a branch. </summary>
    public class Branch
    {
        /// <summary> The name of this branch. </summary>
        public string Name { get; set; }

        /// <summary> Whether or not this branch is protected. </summary>
        public bool? Protected { get; set; }

        /// <summary> The current commit for this branch. </summary>
        public Commit Commit { get; set; }
    }
}