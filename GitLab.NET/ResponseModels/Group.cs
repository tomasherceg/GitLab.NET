using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLab.NET.ResponseModels {
    /// <summary> Stores information about a group. </summary>
    public class Group {
        /// <summary> The GroupId for this group. </summary>
        public uint GroupId { get; set; }

        /// <summary> The GroupName for this group. </summary>
        public string GroupName { get; set; }

        /// <summary> The GroupAccessLevel for this group. </summary>
        public uint GroupAccessLevel { get; set; }
    }
}
