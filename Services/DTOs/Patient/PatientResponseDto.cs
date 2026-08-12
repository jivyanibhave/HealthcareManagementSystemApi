namespace HealthcareApi.Services.DTOs.Patient
{
    public class PatientResponseDto
    {
        public int PatientId { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public string Gender { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
    }
}