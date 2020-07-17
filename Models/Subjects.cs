using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OurEduOEMS.Models
{
    public class Subjects
    {
        [Key]
        public int SubjectId { get; set; }

        [Required]
        [Display(Name ="Subject Name")]
        public string SubjectName { get; set; }
    }
}
