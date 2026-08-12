namespace HealthcareApi.Services.DTOs.Doctor
{
    public class DoctorResponseDto
    {
        public int DoctorId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Specialization { get; set; } = string.Empty;

        public string Qualification { get; set; } = string.Empty;

        public int Experience { get; set; }

        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public decimal ConsultationFee { get; set; }

        public string DepartmentName { get; set; } = string.Empty;
    }
}