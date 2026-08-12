using HealthcareApi.Models;

namespace HealthcareApi.Services.Interface
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetAllAsync();

        Task<Doctor?> GetByIdAsync(int id);

        Task AddAsync(Doctor doctor);

        Task UpdateAsync(Doctor doctor);

        Task DeleteAsync(int id);

        Task<IEnumerable<Doctor>> SearchAsync(string keyword);
    }
}