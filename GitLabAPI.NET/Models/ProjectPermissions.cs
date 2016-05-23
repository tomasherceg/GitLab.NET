﻿using RestSharp.Deserializers;

namespace GitLabAPI.NET.Models
{
    public class ProjectPermissions
    {
        [DeserializeAs(Name = "project_access")]
        public Permission ProjectAccess { get; set; }

        [DeserializeAs(Name = "group_access")]
        public Permission GroupAccess { get; set; }
    }
}