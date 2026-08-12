using System.ComponentModel.DataAnnotations;

namespace HealthcareAPI.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(100)]
        public string DepartmentName { get; set; } = string.Empty;

        // Navigation Property
        public ICollection<Doctor>? Doctors { get; set; }
    }
}