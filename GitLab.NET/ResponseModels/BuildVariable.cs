// ReSharper disable UnusedMember.Global

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about a build variable. </summary>
    public class BuildVariable
    {
        /// <summary> The key for this build variable. </summary>
        public string Key { get; set; }

        /// <summary> The value for this build variable. </summary>
        public string Value { get; set; }
    }
}