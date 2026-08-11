using HealthcareApi.Models;

namespace HealthcareApi.Repository.Interface
{
    public interface IPrescriptionRepository
    {
        Task<IEnumerable<Prescription>> GetAllAsync();

        Task<Prescription?> GetByIdAsync(int id);

        Task<Prescription> AddAsync(Prescription prescription);

        Task<Prescription?> UpdateAsync(Prescription prescription);

        Task<bool> DeleteAsync(int id);

    }
}
