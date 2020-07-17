using OurEduOEMS.Data;
using OurEduOEMS.Models;
using OurEduOEMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurEduOEMS.Services
{
    public class ClassesService : IClasses
    {
        private readonly DataContext _context;

        public ClassesService (DataContext context)
        {
            _context = context;
        }

        public void AddClasses (Classes newClass)
        {
            _context.Classes.Add (newClass);
            _context.SaveChanges ();
        }

        public void DeleteUser (Classes classes)
        {
            _context.Classes.Remove (classes);
            _context.SaveChanges ();
        }

        public List<Classes> GetAllClasses ()
        {
            return _context.Classes.ToList ();
        }

        public Classes GetClasses (int Id)
        {
            return _context.Classes.Find (Id);
        }

        public void UpdateClasses (Classes changeClasses)
        {
            var updatedClass = _context.Classes.Attach (changeClasses);
            updatedClass.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges ();
        }
    }
}
