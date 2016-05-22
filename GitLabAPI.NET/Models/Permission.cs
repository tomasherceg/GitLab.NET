using System;
using System.Runtime.Serialization;

namespace GitLabAPI.NET.Models
{
    [DataContract]
    public class Permission
    {
        [DataMember(Name = "access_level")]
        public AccessLevel AccessLevel { get; set; }

        [DataMember(Name = "notification_level")]
        public NotificationLevel NotificationLevel { get; set; }
    }
}
