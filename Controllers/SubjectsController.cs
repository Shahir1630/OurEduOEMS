using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using OurEduOEMS.Models;
using OurEduOEMS.Services.Interfaces;

namespace OurEduOEMS.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly ISubjects _subjects;
        private readonly IToastNotification _toastNotification;

        public SubjectsController (ISubjects subjects, IToastNotification toastNotification)
        {
            _subjects = subjects;
            _toastNotification = toastNotification;
        }
        public IActionResult Index ()
        {
            return View (_subjects.GetAllSubjects ());
        }

        public IActionResult Create ()
        {
            return View ();
        }

        [HttpPost]
        public IActionResult Create (Subjects subjects)
        {
            if (ModelState.IsValid)
            {
                _subjects.AddSubjects (subjects);
                _toastNotification.AddSuccessToastMessage ("Successfully Created.");
                return RedirectToAction (nameof (Index));
            }
            return View (subjects);
        }

        public IActionResult Edit (int Id)
        {
            var subject = _subjects.GetSubjects (Id);
            if (subject == null)
            {
                _toastNotification.AddErrorToastMessage ("Class Not Found");
                return View (nameof (NotFound));
            }
            return View (subject);
        }

        [HttpPost]
        public IActionResult Edit (Subjects subjects)
        {
            if (ModelState.IsValid)
            {
                _subjects.UpdateSubjects (subjects);
                _toastNotification.AddSuccessToastMessage ("Successfully Edited.");
                return RedirectToAction (nameof (Index));
            }
            return View (subjects);
        }

        public IActionResult Delete (int Id)
        {
            var subject = _subjects.GetSubjects (Id);
            if (subject == null)
            {
                return View (nameof (NotFound));
            }
            _subjects.DeleteSubjects (subject);
            return RedirectToAction (nameof (Index));
        }
    }
}
