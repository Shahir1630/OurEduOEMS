using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurEduOEMS.Models
{
    public class Actors
    {
        public int Id { get; set; }

        public string ActorName { get; set; }

        //public int UserId { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
