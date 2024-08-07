    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace TravelDesk.Models
    {
        public class TravelRequest
        {
            [Key]
            public int Id { get; set; }

            [Required]
            public string EmployeeId { get; set; }

            [Required]
            public string EmployeeName { get; set; }

            [Required]
            public string ProjectName { get; set; }

            [Required]
            public string DepartmentName { get; set; }

            [Required]
            public string TravelReason { get; set; }

            [Required]
            public string BookingType { get; set; }

            [Required]
            public DateTime TravelDate { get; set; }

            [Required]
            public string AadharCard { get; set; }

            public string PassportNumber { get; set; }

            public string VisaFile { get; set; }

            public int? DaysOfStay { get; set; }

            public string MealPreference { get; set; }

            public string Status { get; set; } = "Pending";

            public string Comments { get; set; } = "";

            public DateTime CreatedOn { get; set; } = DateTime.Now;
        }
    }


