﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OurEduOEMS.Models
{
    public class Subjects
    {
        public int Id { get; set; }

        [Required]
        [Display (Name = "Subject Name")]
        public string SubjectName { get; set; }
        public bool IsActive { get; set; }

        public int ClassesId { get; set; }
        public Classes Classes { get; set; }

        public ICollection<AssignedSubjects> AssignedSubjects { get; set; }

    }
}
