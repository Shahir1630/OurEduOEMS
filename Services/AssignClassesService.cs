using Microsoft.EntityFrameworkCore;
using OurEduOEMS.Data;
using OurEduOEMS.Models;
using OurEduOEMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurEduOEMS.Services
{
    public class AssignClassesService : IAssignClasses
    {
        private readonly DataContext _context;

        public AssignClassesService (DataContext context)
        {
            _context = context;
        }

        public void AddAssignClass (AssignedClasses newAssignClass)
        {
            _context.AssignedClasses.Add (newAssignClass);
            _context.SaveChanges ();
        }

        public void DeleteAssignClass (AssignedClasses classes)
        {
            _context.AssignedClasses.Remove (classes);
            _context.SaveChanges ();
        }

        public List<AssignedClasses> GetAllAssignClasses ()
        {
            return _context.AssignedClasses.Include (c => c.Classes).ToList (); 
        }

        public List<Classes> GetAllClasses ()
        {
            return _context.Classes.ToList();
        }

        public AssignedClasses GetAssignClass (int Id)
        {
            return _context.AssignedClasses.Find (Id);
        }

        public void UpdateAssignClass (AssignedClasses changeClass)
        {
            var updatedClass = _context.AssignedClasses.Attach (changeClass);
            updatedClass.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges ();
        }
    }
}
