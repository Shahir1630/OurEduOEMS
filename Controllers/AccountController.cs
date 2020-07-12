using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using OurEduOEMS.Services.Interfaces;
using OurEduOEMS.ViewModels;

namespace OurEduOEMS.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccount _accountRepo;
        private readonly IToastNotification _toastNotification;

        public AccountController (IAccount account, IToastNotification toastNotification)
        {
            _accountRepo = account;
            _toastNotification = toastNotification;
        }

        public IActionResult Login ()
        {
            return View ();
        }

        [HttpPost]
        public IActionResult Login (LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _accountRepo.CheckValidUser (model.Email, model.Password);

                if (user == null)
                {
                    _toastNotification.AddErrorToastMessage ("Invlid User Input. Try Again.");
                    return View (model);
                }

                _toastNotification.AddSuccessToastMessage ("Login Successfull.");
                return RedirectToAction ("Index", "Home");
            }
            return View (model);
        }

        public IActionResult ForgetPassword ()
        {
            return View ();
        }
    }
}
