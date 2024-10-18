using CMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    public class AcademicManagerController : Controller
    {
        private static List<ClaimView> claims = new List<ClaimView>
        {
            new ClaimView { Id = 1, Description = "Claim for September", LecturerName = "John Doe", Status = "Pending" },
            new ClaimView { Id = 2, Description = "Claim for October", LecturerName = "Jane Smith", Status = "Pending" }
        };

        public IActionResult AcademicManagerDashboard()
        {
            return View();
        }

        public IActionResult AcademicAcceptReject()
        {

            return View("AcademicAcceptReject", claims); // Pass the claims to the view
        }


        // POST: Accept a claim
        [HttpPost]
        public IActionResult Accept(int ClaimId)
        {
            var claim = claims.FirstOrDefault(c => c.Id == ClaimId);
            if (claim != null)
            {
                claim.Status = "Accepted"; // Update status to 'Accepted'
            }
            return RedirectToAction("AcademicAcceptReject");
        }

        // POST: Reject a claim
        [HttpPost]
        public IActionResult Reject(int ClaimId)
        {
            var claim = claims.FirstOrDefault(c => c.Id == ClaimId);
            if (claim != null)
            {
                claim.Status = "Rejected"; // Update status to 'Rejected'
            }
            return RedirectToAction("AcademicAcceptReject");
        }
        public IActionResult Logout()
        {
            // Logic for logging out,
            return RedirectToAction("Login", "Login");
        }
    }
}
