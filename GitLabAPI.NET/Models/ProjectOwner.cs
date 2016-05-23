using RestSharp.Deserializers;

namespace GitLabAPI.NET.Models
{
    public class ProjectOwner
    {
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DeserializeAs(Name = "username")]
        public string Username { get; set; }

        [DeserializeAs(Name = "id")]
        public int Id { get; set; }

        [DeserializeAs(Name = "state")]
        public string State { get; set; }

        [DeserializeAs(Name = "avatar_url")]
        public string AvatarUrl { get; set; }

        [DeserializeAs(Name = "web_url")]
        public string WebUrl { get; set; }
    }
}
