using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITStep.First.Models.Entities
{
    public class Profile
    {
        public int Id {get; set;}
        [Required]
        [MaxLength(64)]
        public string Title { get; set; }
        public bool Author { get; set; }
        public Image Cover { get; set; }
        public IEnumerable<Social> Socials { get; set; }
        public string Description { get; set; }
        public Profile()
        {
            Title = "Blog Title";
            Author = false;
            Cover = new Image()
            {
                Uri = "/Files/Images/DefaultProfileCover.jpg",
                Alt = "Profile Cover"
            };
            Socials = new List<Social>();
            Description = "Пустий блог";
        }
    }
}
