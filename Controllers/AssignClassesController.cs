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
    public class AssignClassesController : Controller
    {
        private readonly IAssignClasses _assignClasses;
        private readonly IToastNotification _toastNotification;

        public AssignClassesController (IAssignClasses assignClasses, IToastNotification toastNotification)
        {
            _assignClasses = assignClasses;
            _toastNotification = toastNotification;
        }

        public IActionResult Index ()
        {
            var allClass = _assignClasses.GetAllAssignClasses ();
            return View (allClass);
        } 
        
        public IActionResult Create ()
        {
            ViewData["ClassId"] = new SelectList (_assignClasses.GetAllClasses(), "Id", "ClassName");
            return View ();
        }

        [HttpPost]
        public IActionResult Create ( AssignedClasses assignedClasses)
        {
            if(ModelState.IsValid)
            {
                _assignClasses.AddAssignClass (assignedClasses);
                _toastNotification.AddSuccessToastMessage ("Successfully Created.");
                return RedirectToAction (nameof (Index));
            }
            return View (assignedClasses);
        }

        public IActionResult Edit (int Id)
        {
            var classes = _assignClasses.GetAssignClass (Id);
            ViewData["ClassId"] = new SelectList (_assignClasses.GetAllClasses (), "Id", "ClassName");

            if (classes == null)
            {
                _toastNotification.AddErrorToastMessage ("Class Not Found");
                return View (nameof (NotFound));
            }
            return View (classes);
        }

        [HttpPost]
        public IActionResult Edit (AssignedClasses assignedClasses)
        {
            if (ModelState.IsValid)
            {
                _assignClasses.UpdateAssignClass (assignedClasses);
                _toastNotification.AddSuccessToastMessage ("Successfully Edited.");
                return RedirectToAction (nameof (Index));
            }
            return View (assignedClasses);
        }

        public IActionResult Delete (int Id)
        {
            var classes = _assignClasses.GetAssignClass (Id);
            if (classes == null)
            {
                return View (nameof (NotFound));
            }
            _assignClasses.DeleteAssignClass (classes);
            return RedirectToAction (nameof (Index));
        }
    }
}
