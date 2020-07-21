using OurEduOEMS.Models;
using OurEduOEMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurEduOEMS.Services.Interfaces
{
    public interface IAssignedSubject
    {
        AssignedSubjects GetAssignSubject (int Id);
        List<AssignedSubjects> GetAllAssignSubject ();
        void UpdateAssignSubject (AssignedSubjects changeAssignSub);
        void AddAssignSubject (AssignedSubjects newAssignSubject);
        void DeleteAssignSubject (AssignedSubjects assignedSubjects);


        List<AssignedClasses> GetAllAssignClasses ();
        List<Subjects> GetAllSubject ();
    }

}
