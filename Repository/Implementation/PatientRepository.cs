using HealthcareApi.Data;
using HealthcareApi.Models;
using HealthcareApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace HealthcareApi.Services.Interfaces
{
    public class PatientRepository : IPatientRepo
    {
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }

        // Get All Patients
        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        // Get Patient By Id
        public async Task<Patient?> GetByIdAsync(int id)
        {
            return await _context.Patients.FindAsync(id);
        }

        // Add New Patient
        public async Task<Patient> AddAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();

            return patient;
        }

        // Update Patient
        public async Task UpdateAsync(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }

        // Delete Patient
        public async Task DeleteAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
            }
        }

        // Check Patient Exists
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Patients.AnyAsync(p => p.Id == id);
        }

        // Search Patient
        public async Task<IEnumerable<Patient>> SearchAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await _context.Patients.ToListAsync();
            }

            keyword = keyword.ToLower();

            return await _context.Patients
                .Where(p =>
                    p.Name.ToLower().Contains(keyword) ||
                    p.Gender.ToLower().Contains(keyword) ||
                    p.PhoneNumber.Contains(keyword) ||
                    p.Address.ToLower().Contains(keyword))
                .ToListAsync();
        }
    }
}