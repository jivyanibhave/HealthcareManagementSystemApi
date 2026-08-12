using HealthcareApi.Services.DTOs.Prescription;
using HealthcareApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _service;

        public PrescriptionController(IPrescriptionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllPrescriptions();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var prescription = await _service.GetPrescriptionById(id);
            if (prescription == null)
                return NotFound();

            return Ok(prescription);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePrescriptionDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _service.AddPrescription(dto);

            return CreatedAtAction(nameof(Get), new { id = result.PrescriptionId }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdatePrescriptionDto dto)
        {
            if (id != dto.PrescriptionId)
                return BadRequest();
            var result = await _service.UpdatePrescription(dto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeletePrescription(id);

            if (!deleted)
                return NotFound();

            return Ok("Prescription deleted successfully.");
        }
    }
}
