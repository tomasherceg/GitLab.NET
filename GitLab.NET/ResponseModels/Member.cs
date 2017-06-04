using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLab.NET.ResponseModels
{
    public class Member
    {

        /// <summary> The ID of the user. </summary>
        public int Id { get; set; }

        /// <summary> The username of the project member. </summary>
        public string Username { get; set; }

        /// <summary> The name of the user. </summary>
        public string Name { get; set; }

        /// <summary> The state of the membership. </summary>
        public string State { get; set; }
        
        /// <summary> The date and time the membership was created at. </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary> The date and time the membership expires at. </summary>
        public DateTime? ExpiresAt { get; set; }

        /// <summary> The access level of the project member. </summary>
        public AccessLevel AccessLevel { get; set; }

    }
}
