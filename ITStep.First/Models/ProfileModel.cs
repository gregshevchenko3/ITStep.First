using ITStep.First.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITStep.First.Models
{
    public class ProfileModel
    {
        public string Title { get; set; } = "Empty Blog";
        public string Description { get; set; } = "Empty blog description";
        public Image Cover { get; set; } = new Image()
        {
            Uri = "/Files/Images/DefaultProfileCover.jpg",
            Alt = "Profile Cover"
        };
        public IEnumerable<Social> Socials { get; set; } = new List<Social>();
        public bool IsAdmin { get; set; } = false;
        public bool IsAuthor { get; set; } = false;
    }
}
