using HealthcareApi.Services.DTOs.Appointment;
using HealthcareApi.Services.Interface;
using HealthcareAPI.Models;
using HealthcareAPI.Repository.Interface;


namespace HealthcareAPI.Services.Implementation
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;

        public AppointmentService(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AppointmentResponseDto>> GetAllAppointments()
        {
            var appointments = await _repository.GetAllAsync();

            return appointments.Select(a => new AppointmentResponseDto
            {
                AppointmentId = a.AppointmentId,
                PatientId = a.Patient?.Name ?? string.Empty,
                DoctorId = a.Doctor?.Name ?? string.Empty,
                AppointmentDate = a.AppointmentDate,
                AppointmentTime = a.AppointmentTime,
                Status = a.Status,
                Reason = a.Reason,
                Remarks = a.Remarks
            });
        }
        public async Task<UpdateAppointmentDto?> GetAppointmentById(int id)
        {
            var appointment = await _repository.GetByIdAsync(id);

            if (appointment == null)
                return null;


            return new UpdateAppointmentDto
            {
                AppointmentId = appointment.AppointmentId,
                //PatientId = appointment.Patient?.Name ?? string.Empty,
                //DoctorId = appointment.Doctor?.Name ?? string.Empty,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                AppointmentDate = appointment.AppointmentDate,
                AppointmentTime = appointment.AppointmentTime,
                Status = appointment.Status,
                Reason = appointment.Reason,
                Remarks = appointment.Remarks
            };
        }

        public async Task<AppointmentResponseDto> AddAppointment(CreateAppointmentDto dto)
        {
            var appointment = new Appointment
            {
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                AppointmentDate = dto.AppointmentDate,
                AppointmentTime = dto.AppointmentTime,
                Status = "Pending",
                Reason = dto.Reason,
                Remarks = dto.Remarks
            };

            var result = await _repository.AddAsync(appointment);

            return new AppointmentResponseDto
            {
                AppointmentId = result.AppointmentId,
                PatientId = result.Patient?.Name ?? string.Empty,
                DoctorId = result.Doctor?.Name ?? string.Empty,
                AppointmentDate = result.AppointmentDate,
                AppointmentTime = result.AppointmentTime,
                Status = result.Status,
                Reason = result.Reason,
                Remarks = result.Remarks
            };
        }
        public async Task<AppointmentResponseDto?> UpdateAppointment(UpdateAppointmentDto dto)
        {
            var appointment = new Appointment
            {
                AppointmentId = dto.AppointmentId,
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                AppointmentDate = dto.AppointmentDate,
                AppointmentTime = dto.AppointmentTime,
                Status = dto.Status,
                Reason = dto.Reason,
                Remarks = dto.Remarks
            };


            var result = await _repository.UpdateAsync(appointment);

            if (result == null)
                return null;

            return new AppointmentResponseDto
            {
                AppointmentId = result.AppointmentId,
                PatientId = result.Patient?.Name ?? string.Empty,
                DoctorId = result.Doctor?.Name ?? string.Empty,
                AppointmentDate = result.AppointmentDate,
                AppointmentTime = result.AppointmentTime,
                Status = result.Status,
                Reason = result.Reason,
                Remarks = result.Remarks
            };
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

    }
}
