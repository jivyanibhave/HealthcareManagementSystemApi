using HealthcareApi.Models;
using HealthcareApi.Services;
using HealthcareApi.Services.DTOs.Patient;
using HealthcareApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var patients = await _patientService.GetAllAsync();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var patient = await _patientService.GetByIdAsync(id);

            if (patient == null)
                return NotFound("Patient not found.");

            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePatientDto patient)
        {
            await _patientService.AddAsync(patient);
            return Ok("Patient added successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Patient patient)
        {
            if (id != patient.Id)
                return BadRequest("Patient ID mismatch.");

            await _patientService.UpdateAsync(patient);
            return Ok("Patient updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _patientService.DeleteAsync(id);
            return Ok("Patient deleted successfully.");
        }

        [HttpGet("search/{keyword}")]
        public async Task<IActionResult> Search(string keyword)
        {
            var patients = await _patientService.SearchAsync(keyword);
            return Ok(patients);
        }
    }
}