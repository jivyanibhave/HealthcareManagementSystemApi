using HealthcareApi.Data;
using HealthcareApi.Models;
using HealthcareApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;


namespace HealthcareApi.Repository.Implementation
{
    public class PrescriptionRepository : IPrescriptionRepository   
    {
        private readonly AppDbContext _context;

        public PrescriptionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Prescription>> GetAllAsync()
        {
            return await _context.Prescriptions
                .Include(x => x.Appointment)
                .ToListAsync();
        }

        public async Task<Prescription?> GetByIdAsync(int id)
        {
            return await _context.Prescriptions
                .Include(x => x.Appointment)
                .FirstOrDefaultAsync(x => x.PrescriptionId == id);
        }

        public async Task<Prescription> AddAsync(Prescription prescription)
        {
            _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync();
            return prescription;
        }

        public async Task<Prescription?> UpdateAsync(Prescription prescription)
        {
            var existing = await _context.Prescriptions.FindAsync(prescription.PrescriptionId);

            if (existing == null)
                return null;

            existing.AppointmentId = prescription.AppointmentId;
            existing.MedicineName = prescription.MedicineName;
            existing.Dosage = prescription.Dosage;
            existing.Duration = prescription.Duration;
            existing.Instructions = prescription.Instructions;

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var prescription = await _context.Prescriptions.FindAsync(id);

            if (prescription == null)
                return false;

            _context.Prescriptions.Remove(prescription);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
