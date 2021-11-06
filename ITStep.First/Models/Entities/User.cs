using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITStep.First.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(64)]
        public string Email { get; set; }
        [MaxLength(8)]
        public string Login { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
        [MaxLength(64)]
        public string Secret { get; set; }
        [Required]
        public bool Locked { get; set; }
        public IEnumerable<Role> Roles { get; set; }
        public IEnumerable<UserRoles> UserRoles { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }

        public User()
        {
            Roles = new List<Role>();
            UpdatedAt = CreatedAt = DateTime.UtcNow;
        }
    }
}
