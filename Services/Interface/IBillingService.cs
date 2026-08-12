using HealthcareApi.Services.DTOs.Billing;

namespace HealthcareApi.Services.Interface
{
    public interface IBillingService
    {
        Task<IEnumerable<BillingResponseDto>> GetAllBillings();

        Task<BillingResponseDto?> GetBillingById(int id);

        Task<BillingResponseDto> AddBilling(CreateBillingDto dto);

        Task<BillingResponseDto?> UpdateBilling(UpdateBillingDto dto);

        Task<bool> DeleteBilling(int id);
    }
}