using System;
using System.Diagnostics.CodeAnalysis;
using RestSharp.Deserializers;

namespace GitLab.NET.ResponseModels
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class ProjectNamespace
    {
        [DeserializeAs(Name = "id")]
        public int Id { get; set; }

        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "path")]
        public string Path { get; set; }

        [DeserializeAs(Name = "owner_id")]
        public int OwnerId { get; set; }

        [DeserializeAs(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        [DeserializeAs(Name = "updated_at")]
        public DateTime UpdatedAt { get; set; }

        [DeserializeAs(Name = "description")]
        public string Description { get; set; }

        [DeserializeAs(Name = "avatar")]
        public NamespaceAvatar Avatar { get; set; }

        [DeserializeAs(Name = "membership_lock")]
        public bool MembershipLock { get; set; }

        [DeserializeAs(Name = "share_with_group_lock")]
        public bool ShareWithGroupLock { get; set; }

        [DeserializeAs(Name = "visibility_level")]
        public VisibilityLevel VisibilityLevel { get; set; }

        [DeserializeAs(Name = "last_ldap_sync_at")]
        public DateTime LastLdapSyncAt { get; set; }
    }
}