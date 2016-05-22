using System.Runtime.Serialization;

namespace GitLabAPI.Models
{
    [DataContract]
    public class ProjectPermissions
    {
        [DataMember(Name = "project_access")]
        public Permission ProjectAccess { get; set; }

        [DataMember(Name = "group_access")]
        public Permission GroupAccess { get; set; }
    }
}
