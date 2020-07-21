using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OurEduOEMS.Models
{
    public class Classes
    {
        public int Id { get; set; }

        [Required]
        public string ClassName { get; set; }
        public ICollection<AssignedClasses> AssignedClasses { get; set; }
        
        public ICollection<Subjects> Subjects { get; set; }


    }
}
