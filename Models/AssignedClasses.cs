using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OurEduOEMS.Models
{
    public class AssignedClasses
    {

        public int Id { get; set; }
       
        [MinLength(4),MaxLength(4)]
        [Range (2020, 9999)]
        public string AssigningYear { get; set; }

        public string SectionName { get; set; }

        public int ClassesId { get; set; }
        public Classes Classes { get; set; }

        public ICollection<AssignedSubjects> AssignedSubjects { get; set; }

    }
}
