using HealthcareApi.Models;
using HealthcareApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _service;

        public DoctorController(IDoctorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var doctor = await _service.GetByIdAsync(id);

            if (doctor == null)
                return NotFound();

            return Ok(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            doctor.Id = 0;

            await _service.AddAsync(doctor);

            return Ok(doctor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return BadRequest("Id mismatch.");
            }

            var existing = await _service.GetByIdAsync(id);

            if (existing == null)
            {
                return NotFound("Doctor not found.");
            }

            await _service.UpdateAsync(doctor);

            return Ok("Doctor updated successfully.");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet("search/{keyword}")]
        public async Task<IActionResult> Search(string keyword)
        {
            return Ok(await _service.SearchAsync(keyword));
        }
    }
}