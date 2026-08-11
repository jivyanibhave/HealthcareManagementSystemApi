using HealthcareApi.Data;
using HealthcareApi.Models;
using HealthcareApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace HealthcareApi.Repository.Implementation
{
    public class DoctorRepository : IDoctorRepo
    {
        private readonly AppDbContext _context;

        public DoctorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor?> GetByIdAsync(int id)
        {
            return await _context.Doctors.FindAsync(id);
        }

        public async Task AddAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Doctor doctor)
        {
            var existingDoctor = await _context.Doctors.FindAsync(doctor.Id);

            if (existingDoctor == null)
                return;

            existingDoctor.Name = doctor.Name;
            existingDoctor.Specialization = doctor.Specialization;
            existingDoctor.PhoneNumber = doctor.PhoneNumber;
            existingDoctor.Email = doctor.Email;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);

            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Doctors.AnyAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Doctor>> SearchAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return await _context.Doctors.ToListAsync();

            keyword = keyword.ToLower();

            return await _context.Doctors
                .Where(d =>
                    d.Name.ToLower().Contains(keyword) ||
                    d.Specialization.ToLower().Contains(keyword) ||
                    d.Qualification.ToLower().Contains(keyword))
                .ToListAsync();
        }
    }
}