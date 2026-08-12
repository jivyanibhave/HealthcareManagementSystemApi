using System.ComponentModel.DataAnnotations;

namespace HealthcareApi.Services.DTOs.Appointment
{
    public class UpdateAppointmentDto
    {
        public int AppointmentId { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public TimeSpan AppointmentTime { get; set; }

        public string Status { get; set; } = string.Empty;

        public string Reason { get; set; } = string.Empty;

        public string? Remarks { get; set; }
    }
}