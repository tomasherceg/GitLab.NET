using System.Runtime.Serialization;

namespace GitLabAPI.NET.Models
{
    [DataContract]
    public class ProjectOwner
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "state")]
        public string State { get; set; }

        [DataMember(Name = "avatar_url")]
        public string AvatarUrl { get; set; }

        [DataMember(Name = "web_url")]
        public string WebUrl { get; set; }
    }
}
