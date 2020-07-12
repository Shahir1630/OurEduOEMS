using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using OurEduOEMS.Services.Interfaces;
using OurEduOEMS.ViewModels;

namespace OurEduOEMS.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsers _userRepo;
        private readonly IToastNotification _toastNotification;

        public UsersController (IUsers users, IToastNotification toastNotification)
        {
            _userRepo = users;
            _toastNotification = toastNotification;
        }
        public IActionResult Index ()
        {
            return View (_userRepo.GetAllUser ());
        }
        
        public IActionResult Registration ()
        {
            ViewBag.ActorId = new SelectList (_userRepo.GetAllActor (), "Id", "ActorName");
            return View ();
        }

        [HttpPost]
        public IActionResult Registration (RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                _userRepo.AddUser (model);
                _toastNotification.AddSuccessToastMessage ("Successfully Created.");
                return RedirectToAction (nameof (Index));
            }   
            return View (model);
        }

        public IActionResult Edit (int Id)
        {
            var user = _userRepo.GetUser (Id);
            if (user == null)
            {
                _toastNotification.AddErrorToastMessage ("User Not Found");
                return View (nameof (NotFound));
            }

            var name = user.Name.Split (' ');

            var updateUser = new EditUserViewModel ()
            {
                Id = user.Id,
                FirstName = name[0],
                LastName = name[1],
                Email = user.Email,
                Password = user.Password,
                Actor = user.ActorId,
            };
            ViewBag.ActorId = new SelectList (_userRepo.GetAllActor (), "Id", "ActorName");
            return View (updateUser);
        }

        [HttpPost]
        public IActionResult Edit (EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                _userRepo.UpdateUser (model);
                _toastNotification.AddSuccessToastMessage ("User Edited Successfully.");
                return RedirectToAction ("Index");
            }
            return View (model);
        }

        public IActionResult Details (int Id)
        {
            var user = _userRepo.GetUser (Id);
            if (user == null)
            {
                _toastNotification.AddErrorToastMessage ("User Not Found");
                return View (nameof (NotFound));
            }
            user.Actor = _userRepo.GetActor (user.ActorId);
            return View (user);
        }

        public IActionResult Delete (int Id)
        {
            var user = _userRepo.GetUser (Id);
            if (user == null)
            {
                return View (nameof (NotFound));
            }
            _userRepo.DeleteUser (user);
            return RedirectToAction (nameof (Index));
        }

        [AcceptVerbs ("Get", "Post")]
        public IActionResult IsEmailInUse (string Email)
        {
            var user = _userRepo.GetUserByEmail (Email);

            if (user != null)
            {
                return Json ($"Email {Email} is already in use");
            }
            return Json (true);
        }
    }
}
