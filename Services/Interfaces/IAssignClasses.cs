using OurEduOEMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurEduOEMS.Services.Interfaces
{
    public interface IAssignClasses
    {


        AssignedClasses GetAssignClass (int Id);
        List<AssignedClasses> GetAllAssignClasses ();
        void UpdateAssignClass (AssignedClasses changeClass);
        void AddAssignClass (AssignedClasses newAssignClass);
        void DeleteAssignClass (AssignedClasses classes);


        List<Classes> GetAllClasses ();
    }
}
