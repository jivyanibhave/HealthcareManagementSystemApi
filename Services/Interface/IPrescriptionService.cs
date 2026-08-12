using HealthcareApi.Services.DTOs.Prescription;

namespace HealthcareApi.Services.Interface
{
    public interface IPrescriptionService
    {
        Task<IEnumerable<PrescriptionResponseDto>> GetAllPrescriptions();

        Task<PrescriptionResponseDto?> GetPrescriptionById(int id);

        Task<PrescriptionResponseDto> AddPrescription(CreatePrescriptionDto dto);

        Task<PrescriptionResponseDto?> UpdatePrescription(UpdatePrescriptionDto dto);

        Task<bool> DeletePrescription(int id);

    
    }
}
