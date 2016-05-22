using System.Runtime.Serialization;

namespace GitLabAPI.Models
{
    [DataContract]
    public class NamespaceAvatar
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }
    }
}
