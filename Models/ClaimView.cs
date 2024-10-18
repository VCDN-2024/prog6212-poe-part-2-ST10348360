using System;

namespace CMS.Models
{
    public class ClaimView
    {
        public DateTime ClaimDate { get; set; }
        public int HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }
        public int TotalHoursWorked { get; set; }
        public string DescriptionOfWork { get; set; }
        public string AdditionalNotes { get; set; }
        public int Id { get; set; }
        public string LecturerName { get; set; }
        public string Status { get; set; } = "Pending"; // Default status as 'Pending'
        public string Description { get; set; }

    }
}
