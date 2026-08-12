namespace HealthcareApi.Services.DTOs.Appointment
{
    public class AppointmentResponseDto
    {
        public int AppointmentId { get; set; }

        public string PatientId { get; set; } = string.Empty;

        public string DoctorId { get; set; } = string.Empty;

        public DateTime AppointmentDate { get; set; }

        public TimeSpan AppointmentTime { get; set; }

        public string Status { get; set; } = string.Empty;

        public string Reason { get; set; } = string.Empty;

        public string? Remarks { get; set; }
        //public string PatientId { get; internal set; }
    }
}