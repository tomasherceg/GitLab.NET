// ReSharper disable UnusedMember.Global

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about a GitLab license template. </summary>
    public class License
    {
        /// <summary> The key for this license. </summary>
        public string Key { get; set; }

        /// <summary> The name for this license. </summary>
        public string Name { get; set; }

        /// <summary> The nickname for this license. </summary>
        public string Nickname { get; set; }

        /// <summary> The HTML URL for this license. </summary>
        public string HtmlUrl { get; set; }

        /// <summary> The source URL for this license. </summary>
        public string SourceUrl { get; set; }

        /// <summary> The description for this license. </summary>
        public string Description { get; set; }

        /// <summary> The conditions of this license. </summary>
        public string[] Conditions { get; set; }

        /// <summary> The permissions provided by this license. </summary>
        public string[] Permissions { get; set; }

        /// <summary> The limitations set by this license. </summary>
        public string[] Limitations { get; set; }

        /// <summary> The license content. </summary>
        public string Content { get; set; }
    }
}