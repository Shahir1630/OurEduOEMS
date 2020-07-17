using OurEduOEMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurEduOEMS.Services.Interfaces
{
    public interface IClasses
    {
        Classes GetClasses (int Id);
        List<Classes> GetAllClasses ();

        void UpdateClasses (Classes changeClasses);
        void AddClasses (Classes newClass);
        void DeleteUser (Classes classes);
    }
}
