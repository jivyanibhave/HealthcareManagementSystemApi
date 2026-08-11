namespace HealthcareApi.Repository.Interface
{
    public interface IBillingRepository
    {
        Task<IEnumerable<Billing>> GetAllAsync();

        Task<Billing?> GetByIdAsync(int id);

        Task<Billing> AddAsync(Billing billing);

        Task<Billing?> UpdateAsync(Billing billing);

        Task<bool> DeleteAsync(int id);
    }
}


