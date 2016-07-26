using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLab.NET.ResponseModels {
    public class Comment {

        public string Note { get; set; }

        public User Author { get; set; }
    }
}
