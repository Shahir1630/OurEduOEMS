using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace OurEduOEMS.Models
{
    public class AssignedSubjects
    {
        public int Id { get; set; }
        
        [MinLength (4), MaxLength (4)]
        [Range (2020, 9999)]
        public string Year { get; set; }

        public int SubjectsId { get; set; }
        public Subjects Subjects { get; set; }
        public int AssignedClassesId { get; set; }
        public AssignedClasses AssignedClasses { get; set; }
    }
}
