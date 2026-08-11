using HealthcareApi.Services.Interface;
using HealthcareApi.Models;
using Microsoft.AspNetCore.Mvc;
using HealthcareAPI.Models;
using HealthcareApi.Services.DTOs.Appointment;


namespace HealthcareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // GET: api/Appointment
        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var appointments = await _appointmentService.GetAllAppointments();
            return Ok(appointments);
        }

        // GET: api/Appointment/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(int id)
        {
            var appointment = await _appointmentService.GetAppointmentById(id);

            if (appointment == null)
                return NotFound(new
                {
                    Message = "Appointment not found."
                });

            return Ok(appointment);
        }

        // POST: api/Appointment
        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody]CreateAppointmentDto appointment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdAppointment = await _appointmentService.AddAppointment(appointment);

            return CreatedAtAction(
                nameof(GetAppointmentById),
                new { id = createdAppointment.AppointmentId },
                createdAppointment);
        }

        // PUT: api/Appointment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, UpdateAppointmentDto appointment)
        {
            if (id != appointment.AppointmentId)
                return BadRequest(new
                {
                    Message = "Appointment ID mismatch."
                });

            var updatedAppointment = await _appointmentService.UpdateAppointment(appointment);

            if (updatedAppointment == null)
                return NotFound(new
                {
                    Message = "Appointment not found."
                });

            return Ok(new
            {
                Message = "Appointment updated successfully.",
                Data = updatedAppointment
            });
        }

        // DELETE: api/Appointment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var deleted = await _appointmentService.DeleteAsync(id);

            if (!deleted)
                return NotFound(new
                {
                    Message = "Appointment not found."
                });

            return Ok(new
            {
                Message = "Appointment deleted successfully."
            });
        }
    }
}