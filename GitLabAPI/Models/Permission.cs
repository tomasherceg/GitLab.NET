using System;
using System.Runtime.Serialization;

namespace GitLabAPI.Models
{
    [DataContract]
    public class Permission
    {
        [DataMember(Name = "access_level")]
        public int AccessLevel { get; set; }

        [DataMember(Name = "notification_level")]
        public int NotificationLevel { get; set; }
    }
}
