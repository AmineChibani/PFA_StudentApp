
using Microsoft.AspNetCore.Mvc;
using StudentApp.Models;
using StudentApp.ViewModels;

namespace StudentApp.Controllers
{
    public class AuthenticationController : Controller
    {
        U669885128UZsNtContext Context { get; set; }

        public AuthenticationController(U669885128UZsNtContext Context)
        {
            this.Context = Context;
        }
        

        [ActionName("SignInBasic")]
        public IActionResult SignInBasic()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignInBasic(LoginVM userViewModel)
        {
            if (ModelState.IsValid)
            {

                Admin admin = Context.Admins.FirstOrDefault(u => u.Email == userViewModel.email.ToLower() &&  u.Password == userViewModel.Password);
                if (admin is not null )
                {
                    HttpContext.Session.SetString("Id", admin.Id.ToString());
                    HttpContext.Session.SetString("Nom", admin.Nom);
                    HttpContext.Session.SetString("Prenom", admin.Prenom);
                    HttpContext.Session.SetString("Role", "Admin");
                    return RedirectToAction("Student", "Dashboard");
                }
                else
                {
                    ViewBag.utilisateurExist = "";
                } 
            }
            return View();
        }



        [ActionName("LogoutBasic")]
        public IActionResult LogoutBasic()
        {
            HttpContext.Session.Clear();
            return View();
        }






        [ActionName("PasswordChangeBasic")]
        public IActionResult PasswordChangeBasic()
        {
            return View();
        }

        [ActionName("PasswordChangeCover")]
        public IActionResult PasswordChangeCover()
        {
            return View();
        }

        [ActionName("PasswordResetBasic")]
        public IActionResult PasswordResetBasic()
        {
            return View();
        }

        [ActionName("PasswordResetCover")]
        public IActionResult PasswordResetCover()
        {
            return View();
        }

        [ActionName("LockScreenBasic")]
        public IActionResult LockScreenBasic()
        {
            return View();
        }

        [ActionName("LockScreenCover")]
        public IActionResult LockScreenCover()
        {
            return View();
        }

        

        [ActionName("LogoutCover")]
        public IActionResult LogoutCover()
        {
            return View();
        }

        [ActionName("SuccessMessageBasic")]
        public IActionResult SuccessMessageBasic()
        {
            return View();
        }

        [ActionName("SuccessMessageCover")]
        public IActionResult SuccessMessageCover()
        {
            return View();
        }

        [ActionName("TwoStepVerificationBasic")]
        public IActionResult TwoStepVerificationBasic()
        {
            return View();
        }

        [ActionName("TwoStepVerificationCover")]
        public IActionResult TwoStepVerificationCover()
        {
            return View();
        }

        [ActionName("Offline")]
        public IActionResult Offline()
        {
            return View();
        }

    }
}
