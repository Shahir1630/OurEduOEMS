using OurEduOEMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurEduOEMS.Services.Interfaces
{
    public interface IAccount
    {
        Users CheckValidUser (string Email, string Password);

       

    }
}
