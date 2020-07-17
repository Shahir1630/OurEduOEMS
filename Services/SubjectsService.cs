using OurEduOEMS.Data;
using OurEduOEMS.Models;
using OurEduOEMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurEduOEMS.Services
{
    public class SubjectsService : ISubjects
    {
        private readonly DataContext _context;

        public SubjectsService (DataContext context)
        {
            _context = context;
        }
        public void AddSubjects (Subjects newSubject)
        {
            _context.Subjects.Add (newSubject);
            _context.SaveChanges ();
        }

        public void DeleteSubjects (Subjects subject)
        {
            _context.Subjects.Remove (subject);
            _context.SaveChanges ();
        }

        public List<Subjects> GetAllSubjects ()
        {
            return _context.Subjects.ToList ();
        }

        public Subjects GetSubjects (int Id)
        {
            return _context.Subjects.Find (Id);
        }

        public void UpdateSubjects (Subjects changeSubject)
        {
            var updatedSubject = _context.Subjects.Attach (changeSubject);
            updatedSubject.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges ();
        }
    }
}
