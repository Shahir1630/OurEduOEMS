using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NToastNotify;
using OurEduOEMS.Models;
using OurEduOEMS.Services.Interfaces;

namespace OurEduOEMS.Controllers
{
    public class ClassesController : Controller
    {
        private readonly IClasses _classes;
        private readonly IToastNotification _toastNotification;

        public ClassesController (IClasses classes, IToastNotification toastNotification)
        {
            _classes = classes;
            _toastNotification = toastNotification;
        }
        public IActionResult Index ()
        {
            return View (_classes.GetAllClasses());
        }
        
        public IActionResult Create ()
        {
            return View ();
        }
        
        [HttpPost]
        public IActionResult Create (Classes classes)
        {
            if(ModelState.IsValid)
            {
                _classes.AddClasses (classes);
                _toastNotification.AddSuccessToastMessage ("Successfully Created.");
                return RedirectToAction (nameof(Index));
            }
            return View (classes);
        }
        
        public IActionResult Edit (int Id)
        {
            var classes = _classes.GetClasses (Id);
            if (classes == null)
            {
                _toastNotification.AddErrorToastMessage ("Class Not Found");
                return View (nameof (NotFound));
            }
            return View (classes);
        }
        
        [HttpPost]
        public IActionResult Edit (Classes classes)
        {
            if(ModelState.IsValid)
            {
                _classes.UpdateClasses (classes);
                _toastNotification.AddSuccessToastMessage ("Successfully Edited.");
                return RedirectToAction (nameof(Index));
            }
            return View (classes);
        }

        public IActionResult Delete (int Id)
        {
            var classes = _classes.GetClasses (Id);
            if (classes == null)
            {
                return View (nameof (NotFound));
            }
            _classes.DeleteUser (classes);
            return RedirectToAction (nameof (Index));
        }
    }
}
