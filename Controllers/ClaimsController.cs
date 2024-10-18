/*Code Attribution
 (IIE, Module Manual) Available at (https://advtechonline.sharepoint.com/:b:/r/sites/TertiaryStudents/IIE%20Student%20Materials/New%20Student%20Materials%20CAT/PROG6212/PROG6212_MO.pdf?csf=1&web=1&e=JZfcwO) [online] [Date Accessed: 18 Oct. 2024]
*/

using Microsoft.AspNetCore.Mvc;
using CMS.Models;
using System.Collections.Generic;
using System.IO;

namespace CMS.Controllers
{
    public class ClaimsController : Controller
    {
        private static List<ClaimView> claims = new List<ClaimView>();
        private static DocumentView DocumentView = new DocumentView();

        public IActionResult LecturerDashboard()
        {
            return View();
        }

        public IActionResult SubmitClaim()
        {
            return View(new ClaimView());
        }

        [HttpPost]
        public IActionResult SubmitClaim(ClaimView model)
        {
            if (ModelState.IsValid)
            {
                claims.Add(model); // Save the claim
                return RedirectToAction("ViewClaims"); // Redirect to view claims after submission
            }
            return View(model);
        }

        public IActionResult ViewClaims()
        {
            return View(claims); // Pass the claims list to the view
        }

        public IActionResult UploadDocuments()
        {
            return View(DocumentView);
        }

        [HttpPost]
        public IActionResult UploadDocument(DocumentView model)
        {
            if (model.DocumentFile != null && model.DocumentFile.Length > 0)
            {
                
                var fileName = Path.GetFileName(model.DocumentFile.FileName);
               
                DocumentView.UploadedFiles.Add(fileName); // Add file name to uploaded files list
            }

            return View("UploadDocuments", DocumentView); // Return to the view with updated list
        }
    }
}
