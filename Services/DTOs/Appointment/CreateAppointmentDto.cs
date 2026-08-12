using System.ComponentModel.DataAnnotations;

namespace HealthcareApi.Services.DTOs.Appointment
{
    public class CreateAppointmentDto
    {
        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public TimeSpan AppointmentTime { get; set; }

        public string Reason { get; set; } = string.Empty;

        public string? Remarks { get; set; }
    }
}