using System.Diagnostics.CodeAnalysis;
using RestSharp.Deserializers;

namespace GitLab.NET.ResponseModels
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class Permission
    {
        [DeserializeAs(Name = "access_level")]
        public AccessLevel AccessLevel { get; set; }

        [DeserializeAs(Name = "notification_level")]
        public NotificationLevel NotificationLevel { get; set; }
    }
}