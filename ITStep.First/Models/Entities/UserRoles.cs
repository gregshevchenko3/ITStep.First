using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITStep.First.Models.Entities
{
    public class UserRoles
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
