// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedMember.Global

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about a repository tree item. </summary>
    public class RepositoryTreeItem
    {
        /// <summary> The ID for this tree item. </summary>
        public string Id { get; set; }

        /// <summary> The name of this tree item. </summary>
        public string Name { get; set; }

        /// <summary> The type for this tree item. </summary>
        public string Type { get; set; }

        /// <summary> The mode for this tree item. </summary>
        public string Mode { get; set; }
    }
}