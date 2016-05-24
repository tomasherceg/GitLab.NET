using System.Diagnostics.CodeAnalysis;

namespace GitLab.NET.ResponseModels
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public enum NotificationLevel
    {
        Disabled = 0,
        Participating = 1,
        Watch = 2,
        Global = 3,
        Mention = 4,
    }
}
