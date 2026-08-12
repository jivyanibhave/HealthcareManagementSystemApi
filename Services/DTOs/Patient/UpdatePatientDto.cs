using System.ComponentModel.DataAnnotations;

namespace HealthcareApi.Services.DTOs.Patient
{
    public class UpdatePatientDto
    {
        [Required]
        public int PatientId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public string Gender { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
    }
}