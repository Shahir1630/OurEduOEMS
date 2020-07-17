using OurEduOEMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurEduOEMS.Services.Interfaces
{
    public interface ISubjects
    {
        Subjects GetSubjects (int Id);
        List<Subjects> GetAllSubjects ();

        void UpdateSubjects (Subjects changeSubject);
        void AddSubjects (Subjects newSubject);
        void DeleteSubjects (Subjects subject);
    }
}
