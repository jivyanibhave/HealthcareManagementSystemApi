using HealthcareApi.Models;
using HealthcareApi.Repository.Interface;
using HealthcareApi.Services.DTOs.Patient;

namespace HealthcareApi.Services.Interface
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientResponseDto>> GetAllAsync();
        Task<Patient?> GetByIdAsync(int id);
        Task<PatientResponseDto> AddAsync(CreatePatientDto patient);
        Task UpdateAsync(Patient patient);
        Task DeleteAsync(int id);
        Task<IEnumerable<Patient>> SearchAsync(string keyword);
    }
}