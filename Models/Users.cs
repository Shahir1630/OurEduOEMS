using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OurEduOEMS.Models
{
    public class Users
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        //public string PhotoPath { get; set; }
        public int ActorId { get; set; }
        public Actors Actor { get; set; }
    }
}
