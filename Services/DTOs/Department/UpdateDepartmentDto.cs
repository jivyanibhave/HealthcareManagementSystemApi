using System.ComponentModel.DataAnnotations;

namespace HealthcareApi.Services.DTOs.Department
{
    public class UpdateDepartmentDto
    {
        public int DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; } = string.Empty;
    }
}