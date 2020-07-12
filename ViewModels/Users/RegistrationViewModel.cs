using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OurEduOEMS.ViewModels
{
    public class RegistrationViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Remote (action: "IsEmailInUse", controller: "Users")]
        public string Email { get; set; }

        public string Password { get; set; }

        [Required]
        public int Actor { get; set; }
    }
}
