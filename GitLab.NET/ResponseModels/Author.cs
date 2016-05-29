// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about an author. </summary>
    public class Author
    {
        /// <summary> The ID of the user. </summary>
        public uint Id { get; set; }

        /// <summary> The author's username. </summary>
        public string Username { get; set; }

        /// <summary> The author's name. </summary>
        public string Name { get; set; }

        /// <summary> The state of the author's account. </summary>
        public string State { get; set; }

        /// <summary> The author's avatar URL. </summary>
        public string AvatarUrl { get; set; }

        /// <summary> The web URL for the author's account. </summary>
        public string WebUrl { get; set; }
    }
}