using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentApp.Filters;
using StudentApp.Models;
using StudentApp.ViewModels.Admin;

namespace StudentApp.Controllers
{
    [Isconnected]
    public class ProfileAdminController : Controller
    {
        private readonly U669885128UZsNtContext _context;
        public ProfileAdminController(U669885128UZsNtContext context)
        {
            this._context = context;
        }


        [ActionName("ProfileSimpleAdmin")]
        public IActionResult ProfileSimpleAdmin()
        {
            Admin admin = _context.Admins.FirstOrDefault(u => u.Id == int.Parse(HttpContext.Session.GetString("Id")));
            return View(admin);
        }

        
        [ActionName("ProfileSettingsAdmin")]
        public IActionResult ProfileSettingsAdmin()
        {
            Admin admin = _context.Admins.FirstOrDefault(u => u.Id == int.Parse(HttpContext.Session.GetString("Id")));
            ProfileSettingsAdminVM profile = new ProfileSettingsAdminVM();
            profile.Prenom = admin.Prenom;
            profile.Nom = admin.Nom;
            profile.Email = admin.Email;
            return View(profile);
        }


   
        [ActionName("ProfileSettingsAdmin")]
        [HttpPost]
        public IActionResult ProfileSettingsAdmin(ProfileSettingsAdminVM newAdmin)
        {
            if (ModelState.IsValid)
            {
                Admin admin = _context.Admins.FirstOrDefault(u => u.Id == int.Parse(HttpContext.Session.GetString("Id")));
                admin.Prenom = newAdmin.Prenom;
                admin.Nom = newAdmin.Nom;
                admin.Email = newAdmin.Email;
                _context.SaveChanges();
                HttpContext.Session.SetString("Nom", newAdmin.Nom);
                HttpContext.Session.SetString("Prenom", newAdmin.Prenom);
                return RedirectToAction(nameof(ProfileSimpleAdmin));
            }
            return View(newAdmin);
        }


        [HttpPost]
        public IActionResult UpdatePasswordAdmin(string oldpassword, string newpassword, string confirmpassword)
        {
            if (oldpassword == null)
            {
                return Json(new { success = false, error = 5 });
            }
            if (newpassword == null)
            {
                return Json(new { success = false, error = 6 });
            }
            if (confirmpassword == null)
            {
                return Json(new { success = false, error = 7 });
            }

            if (newpassword.Length < 4)
            {
                return Json(new { success = false, error = 4 });
            }

            if (newpassword == oldpassword)
            {
                return Json(new { success = false, error = 1 });
            }

            if (newpassword != confirmpassword)
            {
                return Json(new { success = false, error = 2 });
            }

            Admin admin = _context.Admins.FirstOrDefault(u => u.Id == int.Parse(HttpContext.Session.GetString("Id")));
            if (admin != null)
            {
                if (admin.Password == oldpassword)
                {
                    admin.Password = newpassword;
                    _context.SaveChanges();
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, error = 3 });
                }
            }

            return Json(new { success = false, error = 4 });
        }

        /*

        [Isconnected(Role = "Client")]
        [HttpPost]
        public IActionResult UpdateCoverClient(IFormFile cover)
        {
            Client client = _context.Clients.FirstOrDefault(a => a.Id == int.Parse(HttpContext.Session.GetString("Id")));
            if (client != null)
            {
                string fileName = $"{DateTime.Now:yyyyMMddHHmmss}-{"@@"}-{cover.Length}-{cover.FileName}";
                string result = VerificationImage.VerifierCover(cover, fileName);

                if (result == "true")
                {
                    VerificationImage.UpdateImage(client.Cover);
                    client.Cover = fileName;
                    _context.SaveChanges();
                    return Json(new { success = true, message = "Le cover a été Modifier avec succès." });
                }
                else
                {
                    return Json(new { success = false, message = result });
                }
            }

            return Json(new { success = false, message = "client nexist pas." });
        }


        [Isconnected(Role = "Client")]
        [HttpPost]
        public IActionResult UpdatePhotoClient(IFormFile photo)
        {
            Client client = _context.Clients.FirstOrDefault(a => a.Id == int.Parse(HttpContext.Session.GetString("Id")));
            if (client != null)
            {
                string fileName = $"{DateTime.Now:yyyyMMddHHmmss}-{"@@"}-{photo.Length}-{photo.FileName}";
                string result = VerificationImage.VerifierImage(photo, fileName);

                if (result == "true")
                {
                    VerificationImage.UpdateImage(client.Cover);
                    client.Photo = fileName;
                    _context.SaveChanges();
                    HttpContext.Session.SetString("Photo", client.Photo);
                    return Json(new { success = true, message = "La Photo a été Modifier avec succès." });
                }
                else
                {
                    return Json(new { success = false, message = result });
                }
            }

            return Json(new { success = false, message = "Client nexist pas." });
        }


        */

    }
}
