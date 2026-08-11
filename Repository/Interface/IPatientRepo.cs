using HealthcareApi.Models;

namespace HealthcareApi.Repository.Interface
{
    public interface IPatientRepo
    {
        // Get all patients
        Task<IEnumerable<Patient>> GetAllAsync();

        // Get patient by Id
        Task<Patient?> GetByIdAsync(int id);

        // Add new patient
        Task<Patient> AddAsync(Patient patient);

        // Update patient
        Task UpdateAsync(Patient patient);

        // Delete patient
        Task DeleteAsync(int id);

        // Check patient exists
        Task<bool> ExistsAsync(int id);

        // Search patients by name
        Task<IEnumerable<Patient>> SearchAsync(string keyword);

    }
}
