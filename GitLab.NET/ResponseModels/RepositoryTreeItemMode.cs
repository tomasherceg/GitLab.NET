// ReSharper disable UnusedMember.Global

namespace GitLab.NET.ResponseModels
{
    /// <summary> Represents a mode in a repository tree item. </summary>
    public enum RepositoryTreeItemMode
    {
        /// <summary> Represents a file. </summary>
        File = 100644,

        /// <summary> Represents an executable file. </summary>
        Executable = 100755,

        /// <summary> Represents a subdirectory. </summary>
        Subdirectory = 040000,

        /// <summary> Represents a submodule. </summary>
        Submodule = 160000,

        /// <summary> Represents a symbolic link. </summary>
        Symlink = 120000
    }
}