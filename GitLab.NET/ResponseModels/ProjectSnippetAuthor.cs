// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

using System;

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about a project snippet's author. </summary>
    public class ProjectSnippetAuthor
    {
        /// <summary> The author's user ID. </summary>
        public uint Id { get; set; }

        /// <summary> The author's username. </summary>
        public string Username { get; set; }

        /// <summary> The author's email address. </summary>
        public string Email { get; set; }

        /// <summary> The author's name. </summary>
        public string Name { get; set; }

        /// <summary> The current state of the author's account. </summary>
        public string State { get; set; }

        /// <summary> The date and time the author's account was created at. </summary>
        public DateTime? CreatedAt { get; set; }
    }
}