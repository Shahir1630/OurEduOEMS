using OurEduOEMS.Models;
using OurEduOEMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurEduOEMS.Services.Interfaces
{
    public interface IUsers
    {
        Users GetUser (int Id);
        List<Users> GetAllUser ();
        void UpdateUser (EditUserViewModel changeUser);
        void AddUser (RegistrationViewModel newUser);
        void DeleteUser (Users user);

        Users GetUserByEmail (string Email);
        List<Actors> GetAllActor ();
        Actors GetActor (int Id);
    }
}
