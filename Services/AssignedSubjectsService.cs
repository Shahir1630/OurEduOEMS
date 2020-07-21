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
    public class AssignedSubjectsService : IAssignedSubject
    {
        private readonly DataContext _context;

        public AssignedSubjectsService (DataContext context)
        {
            _context = context;
        }
        public void AddAssignSubject (AssignedSubjects newAssignSubject)
        {
            _context.AssignedSubjects.Add (newAssignSubject);
            _context.SaveChanges ();
        }

        public void DeleteAssignSubject (AssignedSubjects assignedSubjects)
        {
            _context.AssignedSubjects.Remove (assignedSubjects);
            _context.SaveChanges ();
        }

        public List<AssignedClasses> GetAllAssignClasses ()
        {
            var allAssignClass= _context.AssignedClasses.Include(c=> c.Classes).ToList ();
            return allAssignClass;
        }

        public List<AssignedSubjects> GetAllAssignSubject ()
        {
            return _context.AssignedSubjects.Include (ac => ac.AssignedClasses.Classes).Include (s => s.Subjects).ToList ();
        }

        public List<Subjects> GetAllSubject ()
        {
            return _context.Subjects.ToList ();
        }

        public AssignedSubjects GetAssignSubject (int Id)
        {
            return _context.AssignedSubjects.Find (Id);
        }

        public void UpdateAssignSubject (AssignedSubjects changeAssignSub)
        {
            var updateAssignSub = _context.AssignedSubjects.Attach (changeAssignSub);
            updateAssignSub.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges ();
        }
    }
}
