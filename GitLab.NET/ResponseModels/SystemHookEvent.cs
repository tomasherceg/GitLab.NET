// ReSharper disable UnusedMember.Global

namespace GitLab.NET.ResponseModels
{
    /// <summary> Stores information about a system hook event. </summary>
    public class SystemHookEvent
    {
        /// <summary> The ID of the project this event was fired for. </summary>
        public uint ProjectId { get; set; }

        /// <summary> The name of the project this event was fired for. </summary>
        public string Name { get; set; }

        /// <summary> The path of the project this event was fired for. </summary>
        public string Path { get; set; }

        /// <summary> The name of this event. </summary>
        public string EventName { get; set; }

        /// <summary> The email address of the owner of the project this event was fired for. </summary>
        public string OwnerEmail { get; set; }

        /// <summary> The name of the owner of the project this event was fired for. </summary>
        public string OwnerName { get; set; }
    }
}