using HealthcareApi.Models;
using HealthcareApi.Repository.Interface;
using HealthcareApi.Services.Interface;

namespace HealthcareApi.Services.Implementation
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepo _repo;

        public DoctorService(IDoctorRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
            => await _repo.GetAllAsync();

        public async Task<Doctor?> GetByIdAsync(int id)
            => await _repo.GetByIdAsync(id);

        public async Task AddAsync(Doctor doctor)
            => await _repo.AddAsync(doctor);

        public async Task UpdateAsync(Doctor doctor)
            => await _repo.UpdateAsync(doctor);

        public async Task DeleteAsync(int id)
            => await _repo.DeleteAsync(id);

        public async Task<IEnumerable<Doctor>> SearchAsync(string keyword)
            => await _repo.SearchAsync(keyword);
    }
}