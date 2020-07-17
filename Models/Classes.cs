using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OurEduOEMS.Models
{
    public class Classes
    {
        [Key]
        public int ClassId { get; set; }
        [Required]
        public string ClassName { get; set; }

    }
}
