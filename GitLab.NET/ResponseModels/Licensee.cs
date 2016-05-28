// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about a GitLab licensee. </summary>
    public class Licensee
    {
        /// <summary> The licensee's name. </summary>
        public string Name { get; set; }

        /// <summary> The licensee's company name. </summary>
        public string Company { get; set; }

        /// <summary> The licensee's email address. </summary>
        public string Email { get; set; }
    }
}