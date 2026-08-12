using HealthcareApi.Repository.Interface;
using HealthcareApi.Services.DTOs.Billing;
using HealthcareApi.Services.Interface;

namespace HealthcareApi.Services.Implementation
{
    public class BillingService : IBillingService
    {
        private readonly IBillingRepository _repository;

        public BillingService(IBillingRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BillingResponseDto>> GetAllBillings()
        {
            var billings = await _repository.GetAllAsync();

            return billings.Select(b => new BillingResponseDto
            {
                BillId = b.BillId,
                PatientId = b.PatientId,
                AppointmentId = b.AppointmentId,
                ConsultationFee = b.ConsultationFee,
                MedicineFee = b.MedicineFee,
                LabFee = b.LabFee,
                Discount = b.Discount,
                GST = b.GST,
                TotalAmount = b.TotalAmount,
                PaymentStatus = b.PaymentStatus
            });
        }

        public async Task<BillingResponseDto?> GetBillingById(int id)
        {
            var billing = await _repository.GetByIdAsync(id);

            if (billing == null)
                return null;

            return new BillingResponseDto
            {
                BillId = billing.BillId,
                PatientId = billing.PatientId,
                AppointmentId = billing.AppointmentId,
                ConsultationFee = billing.ConsultationFee,
                MedicineFee = billing.MedicineFee,
                LabFee = billing.LabFee,
                Discount = billing.Discount,
                GST = billing.GST,
                TotalAmount = billing.TotalAmount,
                PaymentStatus = billing.PaymentStatus
            };
        }

        public async Task<BillingResponseDto> AddBilling(CreateBillingDto dto)
        {
            var billing = new Billing
            {
                PatientId = dto.PatientId,
                AppointmentId = dto.AppointmentId,
                ConsultationFee = dto.ConsultationFee,
                MedicineFee = dto.MedicineFee,
                LabFee = dto.LabFee,
                Discount = dto.Discount,
                GST = dto.GST,
                //TotalAmount = dto.TotalAmount,
                PaymentStatus = dto.PaymentStatus
            };

            var result = await _repository.AddAsync(billing);

            return new BillingResponseDto
            {
                BillId = result.BillId,
                PatientId = result.PatientId,
                AppointmentId = result.AppointmentId,
                ConsultationFee = result.ConsultationFee,
                MedicineFee = result.MedicineFee,
                LabFee = result.LabFee,
                Discount = result.Discount,
                GST = result.GST,
                TotalAmount = result.TotalAmount,
                PaymentStatus = result.PaymentStatus
            };
        }

        public async Task<BillingResponseDto?> UpdateBilling(UpdateBillingDto dto)
        {
            var billing = new Billing
            {
                BillId = dto.BillId,
                PatientId = dto.PatientId,
                AppointmentId = dto.AppointmentId,
                ConsultationFee = dto.ConsultationFee,
                MedicineFee = dto.MedicineFee,
                LabFee = dto.LabFee,
                Discount = dto.Discount,
                GST = dto.GST,
                TotalAmount = dto.TotalAmount,
                PaymentStatus = dto.PaymentStatus
            };

            var result = await _repository.UpdateAsync(billing);

            if (result == null)
                return null;

            return new BillingResponseDto
            {
                BillId = result.BillId,
                PatientId = result.PatientId,
                AppointmentId = result.AppointmentId,
                ConsultationFee = result.ConsultationFee,
                MedicineFee = result.MedicineFee,
                LabFee = result.LabFee,
                Discount = result.Discount,
                GST = result.GST,
                TotalAmount = result.TotalAmount,
                PaymentStatus = result.PaymentStatus
            };
        }

        public async Task<bool> DeleteBilling(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}






            
