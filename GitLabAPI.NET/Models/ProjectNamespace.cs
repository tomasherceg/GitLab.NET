using System;
using System.Runtime.Serialization;

namespace GitLabAPI.NET.Models
{
    [DataContract]
    public class ProjectNamespace
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "path")]
        public string Path { get; set; }

        [DataMember(Name = "owner_id")]
        public int OwnerId { get; set; }

        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "updated_at")]
        public DateTime UpdatedAt { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "avatar")]
        public NamespaceAvatar Avatar { get; set; }

        [DataMember(Name = "membership_lock")]
        public bool MembershipLock { get; set; }

        [DataMember(Name = "share_with_group_lock")]
        public bool ShareWithGroupLock { get; set; }

        [DataMember(Name = "visibility_level")]
        public VisibilityLevel VisibilityLevel { get; set; }

        [DataMember(Name = "last_ldap_sync_at")]
        public DateTime LastLdapSyncAt { get; set; }
    }
}
