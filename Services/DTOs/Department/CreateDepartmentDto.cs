using System.ComponentModel.DataAnnotations;

namespace HealthcareApi.Services.DTOs.Department
{
    public class CreateDepartmentDto
    {
        [Required]
        public string DepartmentName { get; set; } = string.Empty;
    }
}