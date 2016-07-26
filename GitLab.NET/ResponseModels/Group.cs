using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLab.NET.ResponseModels {
    public class Group {

        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public int GroupAccessLevel { get; set; }
    }
}
