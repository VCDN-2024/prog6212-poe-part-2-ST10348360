using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CMS.Models
{
    public class DocumentView
    {
        public IFormFile DocumentFile { get; set; } // To hold the uploaded file
        public List<string> UploadedFiles { get; set; } = new List<string>(); // To hold uploaded file names
    }
}
