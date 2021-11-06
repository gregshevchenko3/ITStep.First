using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITStep.First.Models.Entities
{
    public class Parameter
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(32)]
        public string Key { get; set; }
        
        [MaxLength(256)]
        public string Value { get; set; }

        public int Order { get; set; }

        public string Group { get; set; }
    }
}
