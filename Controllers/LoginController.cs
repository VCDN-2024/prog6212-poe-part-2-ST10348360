//Code Attribution
/*https://stackoverflow.com/questions/16321736/how-can-i-post-a-list-of-items-in-mvc
 Author: Simon Martin
 */

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using CMS.Models;

namespace CMS.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginView model)
        {

            if (model.Username == "lecturer" && model.Password == "password1")
            {
                ViewData["Role"] = "Lecturer";
                // Redirect to the lecturer dashboard upon successful login
                return RedirectToAction("LecturerDashboard", "Claims");
            }
            if (model.Username == "ProgrammeCoordinator" && model.Password == "password2")
            {
                ViewData["Role"] = "ProgrammeCoordinator";
                // Redirect to the lecturer dashboard upon successful login
                return RedirectToAction("ProgrammeCoordinatorDashboard", "ProgrammeCoordinator");
            }
            if (model.Username == "AcademicManager" && model.Password == "password3")
            {
                ViewData["Role"] = "AcademicManager";
                // Redirect to the lecturer dashboard upon successful login
                return RedirectToAction("AcademicManagerDashboard", "AcademicManager");
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(model);
        }

        public IActionResult Logout()
        {
            // Logic for logging out,
            return RedirectToAction("Login", "Login");
        }
    }
}

