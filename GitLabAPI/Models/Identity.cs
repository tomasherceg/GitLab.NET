using System.Runtime.Serialization;

namespace GitLabAPI.Models
{
    [DataContract]
    public class Identity
    {
        [DataMember(Name = "provider")]
        public string Provider { get; set; }

        [DataMember(Name = "extern_uid")]
        public string ExternUid { get; set; }
    }
}
