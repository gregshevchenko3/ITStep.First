using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITStep.First.Models.Entities
{
    public class Role
    {
        public int Id { get; set; }
        [MaxLength(8)]
        [Required]
        public string Name { get; set; }
        [MaxLength(128)]
        public string Description { get; set; }
        public IEnumerable<UserRoles> RoleUsers { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
