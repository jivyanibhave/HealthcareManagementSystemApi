using System.ComponentModel.DataAnnotations;

namespace HealthcareApi.Services.DTOs.Prescription
{
    public class UpdatePrescriptionDto
    {
        [Required]
        public int PrescriptionId { get; set; }

        [Required]
        public int AppointmentId { get; set; }

        [Required]
        public string MedicineName { get; set; } = string.Empty;

        [Required]
        public string Dosage { get; set; } = string.Empty;

        [Required]
        public string Duration { get; set; } = string.Empty;

        public string? Instructions { get; set; }

    }
}
