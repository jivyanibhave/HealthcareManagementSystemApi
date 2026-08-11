using HealthcareApi.Data;
using HealthcareApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace HealthcareApi.Repository.Implementation
{
    public class BillingRepository : IBillingRepository
    {
        private readonly AppDbContext _context;

        public BillingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Billing>> GetAllAsync()
        {
            return await _context.Billings
                .Include(b => b.Patient)
                .Include(b => b.Appointment)
                .ToListAsync();
        }

        public async Task<Billing?> GetByIdAsync(int id)
        {
            return await _context.Billings
                .Include(b => b.Patient)
                .Include(b => b.Appointment)
                .FirstOrDefaultAsync(x => x.BillId == id);
        }

        public AppDbContext Get_context1()
        {
            return _context;
        }

        public async Task<Billing> AddAsync(Billing billings)
        {
            _context.Billings.Add(billings);
            await _context.SaveChangesAsync();
            return billings;
        }

        public async Task<Billing?> UpdateAsync(Billing billing)
        {
            var existing = await _context.Billings.FindAsync(billing.BillId);

            if (existing == null)
                return null;

            existing.PatientId = billing.PatientId;
            existing.AppointmentId = billing.AppointmentId;
            existing.ConsultationFee = billing.ConsultationFee;
            existing.MedicineFee = billing.MedicineFee;
            existing.LabFee = billing.LabFee;
            existing.Discount = billing.Discount;
            existing.GST = billing.GST;
            existing.TotalAmount = billing.TotalAmount;
            existing.PaymentStatus = billing.PaymentStatus;

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var billing = await _context.Billings.FindAsync(id);
            if (billing == null)
                return false;

            _context.Billings.Remove(billing);

            await _context.SaveChangesAsync();

            return true;
        }

        //public Task<Billing> AddAsync(Billing billing)
        //{
        //    throw new NotImplementedException();
        //}
    }
}






        
