namespace HealthcareApi.Services.DTOs.Prescription
{
    public class PrescriptionResponseDto
    {
        public int PrescriptionId { get; set; }

        public int AppointmentId { get; set; }

        public string MedicineName { get; set; } = string.Empty;

        public string Dosage { get; set; } = string.Empty;

        public string Duration { get; set; } = string.Empty;

        public string? Instructions { get; set; }

    }
}
