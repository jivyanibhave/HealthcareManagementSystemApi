using HealthcareApi.Models;
using HealthcareApi.Repository.Interface;
using HealthcareApi.Services.DTOs.Prescription;
using HealthcareApi.Services.Interface;

namespace HealthcareApi.Services.Implementation
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _repository;

        public PrescriptionService(IPrescriptionRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<PrescriptionResponseDto>> GetAllPrescriptions()
        {
            var prescriptions = await _repository.GetAllAsync();

            return prescriptions.Select(x => new PrescriptionResponseDto
            {
                PrescriptionId = x.PrescriptionId,
                AppointmentId = x.AppointmentId,
                MedicineName = x.MedicineName,
                Dosage = x.Dosage,
                Duration = x.Duration,
                Instructions = x.Instructions
            });
        }

        public async Task<PrescriptionResponseDto?> GetPrescriptionById(int id)
        {
            var prescription = await _repository.GetByIdAsync(id);

            if (prescription == null)
                return null;

            return new PrescriptionResponseDto
            {
                PrescriptionId = prescription.PrescriptionId,
                AppointmentId = prescription.AppointmentId,
                MedicineName = prescription.MedicineName,
                Dosage = prescription.Dosage,
                Duration = prescription.Duration,
                Instructions = prescription.Instructions
            };
        }
        public async Task<PrescriptionResponseDto> AddPrescription(CreatePrescriptionDto dto)
        {
            var prescription = new Prescription
            {
                AppointmentId = dto.AppointmentId,
                MedicineName = dto.MedicineName,
                Dosage = dto.Dosage,
                Duration = dto.Duration,
                Instructions = dto.Instructions
            };

            var result = await _repository.AddAsync(prescription);

            return new PrescriptionResponseDto
            {
                PrescriptionId = result.PrescriptionId,
                AppointmentId = result.AppointmentId,
                MedicineName = result.MedicineName,
                Dosage = result.Dosage,
                Duration = result.Duration,
                Instructions = result.Instructions
            };
        }
        public async Task<PrescriptionResponseDto?> UpdatePrescription(UpdatePrescriptionDto dto)
        {
            var prescription = new Prescription
            {
                PrescriptionId = dto.PrescriptionId,
                AppointmentId = dto.AppointmentId,
                MedicineName = dto.MedicineName,
                Dosage = dto.Dosage,
                Duration = dto.Duration,
                Instructions = dto.Instructions
            };

            var result = await _repository.UpdateAsync(prescription);

            if (result == null)
                return null;
            return new PrescriptionResponseDto
            {
                PrescriptionId = result.PrescriptionId,
                AppointmentId = result.AppointmentId,
                MedicineName = result.MedicineName,
                Dosage = result.Dosage,
                Duration = result.Duration,
                Instructions = result.Instructions
            };
        }

        public async Task<bool> DeletePrescription(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}









    

