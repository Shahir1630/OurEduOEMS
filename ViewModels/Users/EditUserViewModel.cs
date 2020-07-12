using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OurEduOEMS.ViewModels
{
    public class EditUserViewModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

        [Required]
        public int Actor { get; set; }
        //public string ExistingPhotoPath { get; set; }
    }
}
