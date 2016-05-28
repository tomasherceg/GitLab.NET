// ReSharper disable UnusedMember.Global

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about an email address. </summary>
    public class EmailAddress
    {
        /// <summary> The ID for this email address. </summary>
        public uint Id { get; set; }

        /// <summary> The email address. </summary>
        public string Email { get; set; }
    }
}