using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITStep.First.Models.Entities
{
    public class Image
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Uri { get; set; }

        [Required]
        [MaxLength(32)]
        public string Alt { get; set; }
    }
}
