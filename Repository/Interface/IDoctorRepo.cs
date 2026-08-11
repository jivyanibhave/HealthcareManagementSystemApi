using HealthcareApi.Models;

namespace HealthcareApi.Repository.Interface
{
    public interface IDoctorRepo
    {
        Task<IEnumerable<Doctor>> GetAllAsync();

        Task<Doctor?> GetByIdAsync(int id);

        Task AddAsync(Doctor doctor);

        Task UpdateAsync(Doctor doctor);

        Task DeleteAsync(int id);

        Task<bool> ExistsAsync(int id);

        Task<IEnumerable<Doctor>> SearchAsync(string keyword);
    }
}