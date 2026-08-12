using HealthcareApi.Models;
using HealthcareApi.Services.DTOs.Appointment;
using HealthcareAPI.Models;

namespace HealthcareApi.Services.Interface
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentResponseDto>> GetAllAppointments();

        Task<UpdateAppointmentDto?> GetAppointmentById(int id);

        Task<AppointmentResponseDto> AddAppointment(CreateAppointmentDto appointment);

        Task<AppointmentResponseDto?> UpdateAppointment(UpdateAppointmentDto appointment);

        Task<bool> DeleteAsync(int id);
    }
}