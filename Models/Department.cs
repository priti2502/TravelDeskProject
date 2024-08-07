using System.ComponentModel.DataAnnotations;

namespace TravelDesk.Models
{
    public class Department
    {

        public int DepartmentId   { get; set; }
        [Required]
        [StringLength(50)]
        public string DepartmentName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
