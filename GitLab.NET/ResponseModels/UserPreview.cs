// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores a snippet of information about a user. </summary>
    public class UserPreview
    {
        /// <summary> The ID of the user. </summary>
        public uint Id { get; set; }

        /// <summary> The user's username. </summary>
        public string Username { get; set; }

        /// <summary> The user's name. </summary>
        public string Name { get; set; }

        /// <summary> The state of the user's account. </summary>
        public string State { get; set; }

        /// <summary> The user's avatar URL. </summary>
        public string AvatarUrl { get; set; }

        /// <summary> The web URL for the user's account. </summary>
        public string WebUrl { get; set; }
    }
}