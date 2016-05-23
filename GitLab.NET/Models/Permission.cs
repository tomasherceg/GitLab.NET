using RestSharp.Deserializers;
using System;

namespace GitLab.NET.Models
{
    public class Permission
    {
        [DeserializeAs(Name = "access_level")]
        public AccessLevel AccessLevel { get; set; }

        [DeserializeAs(Name = "notification_level")]
        public NotificationLevel NotificationLevel { get; set; }
    }
}
