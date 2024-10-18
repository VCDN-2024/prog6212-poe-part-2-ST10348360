/*Code Attribution
 (IIE, Module Manual) Available at (https://advtechonline.sharepoint.com/:b:/r/sites/TertiaryStudents/IIE%20Student%20Materials/New%20Student%20Materials%20CAT/PROG6212/PROG6212_MO.pdf?csf=1&web=1&e=JZfcwO) [online] [Date Accessed: 18 Oct. 2024]
*/

using Microsoft.AspNetCore.Mvc;
using CMS.Models;
using System.Collections.Generic;
using System.IO;

namespace CMS.Controllers
{
    public class ProgrammeCoordinatorController : Controller
    {
        private static List<ClaimView> claims = new List<ClaimView>
        {
            new ClaimView { Id = 1, Description = "Claim for September", LecturerName = "John Doe", Status = "Pending" },
            new ClaimView { Id = 2, Description = "Claim for October", LecturerName = "Jane Smith", Status = "Pending" }
        };

       

        // GET: Dashboard with claims list
        public IActionResult ProgrammeCoordinatorDashboard()
        {
            return View();
        }

        public IActionResult AcceptRejectClaims()
        {
            
            return View("AcceptRejectClaims", claims); // Pass the claims to the view
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
            return RedirectToAction("AcceptRejectClaims");
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
            return RedirectToAction("AcceptRejectClaims");
        }

        public IActionResult Logout()
        {
            // Logic for logging out,
            return RedirectToAction("Login", "Login");
        }
    }
}
