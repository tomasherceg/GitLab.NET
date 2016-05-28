// ReSharper disable UnusedMember.Global

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information for a namespace. </summary>
    public class Namespace
    {
        /// <summary> The ID for this namespace. </summary>
        public uint Id { get; set; }

        /// <summary> The path for this namespace. </summary>
        public string Path { get; set; }

        /// <summary> The kind for this namespace. </summary>
        public string Kind { get; set; }
    }
}