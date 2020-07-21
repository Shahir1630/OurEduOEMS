using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using OurEduOEMS.Models;
using OurEduOEMS.Services.Interfaces;

namespace OurEduOEMS.Controllers
{
    public class AssignedSubjectsController : Controller
    {
        private readonly IAssignedSubject _assignedSubject;
        private readonly IToastNotification _toastNotification;

        public AssignedSubjectsController (IAssignedSubject assignedSubject, IToastNotification toastNotification)
        {
            _assignedSubject = assignedSubject;
            _toastNotification = toastNotification;
        }
        public IActionResult Index ()
        {
            var allAssignSub = _assignedSubject.GetAllAssignSubject ();
            return View (allAssignSub);
        }
        
        public IActionResult Create ()
        {
            ViewData["AssignClassId"] = new SelectList (_assignedSubject.GetAllAssignClasses (), "Id", "Classes.ClassName");
            ViewData["SubjectId"] = new SelectList (_assignedSubject.GetAllSubject (), "Id", "SubjectName");
            return View ();
        }

        [HttpPost]
        public IActionResult Create (AssignedSubjects assignedSubjects )
        {
            if(ModelState.IsValid)
            {
                _assignedSubject.AddAssignSubject (assignedSubjects);
                _toastNotification.AddSuccessToastMessage ("Successfully Created.");
                return RedirectToAction (nameof (Index));
            }
            return View (assignedSubjects);
        } 
        
        public IActionResult Edit (int Id)
        {
            var assignedSubjects = _assignedSubject.GetAssignSubject (Id);

            if (assignedSubjects == null)
            {
                _toastNotification.AddErrorToastMessage ("Class Not Found");
                return View (nameof (NotFound));
            }
            ViewData["AssignClassId"] = new SelectList (_assignedSubject.GetAllAssignClasses (), "Id", "Classes.ClassName");
            ViewData["SubjectId"] = new SelectList (_assignedSubject.GetAllSubject (), "Id", "SubjectName");
            return View (assignedSubjects);
        }

        [HttpPost]
        public IActionResult Edit (AssignedSubjects assignedSubjects )
        {
            if(ModelState.IsValid)
            {
                _assignedSubject.UpdateAssignSubject (assignedSubjects);
                _toastNotification.AddSuccessToastMessage ("Successfully Edited.");
                return RedirectToAction (nameof (Index));
            }
            return View (assignedSubjects);
        }

        public IActionResult Delete (int Id)
        {
            var assignedSubject = _assignedSubject.GetAssignSubject (Id);
            if (assignedSubject == null)
            {
                return View (nameof (NotFound));
            }
            _assignedSubject.DeleteAssignSubject (assignedSubject);
            return RedirectToAction (nameof (Index));
        }
    }
}
