using HealthcareApi.Models;
using HealthcareApi.Repository.Interface;
using HealthcareApi.Services.DTOs.Patient;
using HealthcareApi.Services.Interface;

namespace HealthcareApi.Services.Implementation
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepo _repository;

        public PatientService(IPatientRepo repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PatientResponseDto>> GetAllAsync()
        {
            var patients = await _repository.GetAllAsync();

            return patients.Select(p => new PatientResponseDto
            {
                PatientId = p.Id,
                Name = p.Name,
                Age = p.Age,
                Gender = p.Gender,
                PhoneNumber = p.PhoneNumber,
                Address = p.Address
            });
        }

        public async Task<Patient?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<PatientResponseDto> AddAsync(CreatePatientDto patient)
        {
            Patient patient1 = new Patient
            {
                Name = patient.Name,
                Age = patient.Age,
                Gender = patient.Gender,
                PhoneNumber = patient.PhoneNumber,
                Address = patient.Address,
            };
            var result = await _repository.AddAsync(patient1);

            return new PatientResponseDto
            {
                PatientId = result.Id,
                Name = result.Name,
                Age = result.Age,
                Gender = result.Gender,
                PhoneNumber = result.PhoneNumber,
                Address = result.Address,
            };
        }

        public async Task UpdateAsync(Patient patient)
        {
            await _repository.UpdateAsync(patient);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Patient>> SearchAsync(string keyword)
        {
            return await _repository.SearchAsync(keyword);
        }

        
    }
}