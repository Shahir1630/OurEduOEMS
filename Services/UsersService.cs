using Microsoft.EntityFrameworkCore;
using OurEduOEMS.Data;
using OurEduOEMS.Models;
using OurEduOEMS.Services.Interfaces;
using OurEduOEMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurEduOEMS.Services
{
    public class UsersService : IUsers
    {
        private readonly DataContext _context;

        public UsersService (DataContext context)
        {
            _context = context;
        }

        public void AddUser (RegistrationViewModel newUser)
        {
            var user = new Users ()
            {
                Name = $"{newUser.FirstName} {newUser.LastName}",
                Email = newUser.Email,
                Password = newUser.Password,
                ActorId = newUser.Actor
            };
            _context.Users.Add (user);
            _context.SaveChanges ();
        }

       
        public void DeleteUser (Users user)
        {
            _context.Users.Remove (user);
            _context.SaveChanges ();
        }

        public Actors GetActor (int Id)
        {
            return _context.Actors.Find (Id);
        }

        public List<Actors> GetAllActor ()
        {
            return _context.Actors.ToList ();
        }

        public List<Users> GetAllUser ()
        {
            return _context.Users.Include (x => x.Actor).ToList ();
        }

        public Users GetUserByEmail (string Email)
        {
            return _context.Users.FirstOrDefault (x => x.Email.Equals (Email));
        }

        public Users GetUser (int Id)
        {
            return _context.Users.Find (Id);
        }

        public void UpdateUser (EditUserViewModel changeUser)
        {
            var user = GetUser (changeUser.Id);
            user.Name = $"{changeUser.FirstName} {changeUser.LastName}";
            user.Email = changeUser.Email;
            user.Password = changeUser.Password;
            user.ActorId = changeUser.Actor;
            
            var updatedUser = _context.Users.Attach (user);
            updatedUser.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges ();
        }
    }
}
