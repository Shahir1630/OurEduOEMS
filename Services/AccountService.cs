using OurEduOEMS.Data;
using OurEduOEMS.Models;
using OurEduOEMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurEduOEMS.Services
{
    public class AccountService : IAccount
    {
        private readonly DataContext _context;

        public AccountService (DataContext context)
        {
            _context = context;
        }

        public Users CheckValidUser (string Email, string Password)
        {
            return _context.Users.FirstOrDefault (x => x.Email.Equals (Email)
                    && x.Password.Equals (Password));
        }
    }
}
