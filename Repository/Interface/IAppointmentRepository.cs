using HealthcareAPI.Models;

namespace HealthcareAPI.Repository.Interface
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAsync();

        Task<Appointment?> GetByIdAsync(int id);

        Task<Appointment> AddAsync(Appointment appointment);

        Task<Appointment?> UpdateAsync(Appointment appointment);

        Task<bool> DeleteAsync(int id);
    }
}