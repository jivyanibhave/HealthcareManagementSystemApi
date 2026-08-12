using HealthcareApi.Services.DTOs.Department;
using HealthcareApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService) => _departmentService = departmentService;

        // GET: api/Department
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = await _departmentService.GetAllDepartments();
            return Ok(departments);
        }

        // GET: api/Department/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var department = await _departmentService.GetDepartmentById(id);

            if (department == null)
                return NotFound(new
                {
                    Message = "Department not found."
                });

            return Ok(department);
        }

        // POST: api/Department
        [HttpPost]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentDto dto)
        {
            var department = await _departmentService.AddDepartment(dto);

            return CreatedAtAction(
                nameof(GetDepartmentById),
                new { id = department.DepartmentId },
                department);
        }

        // PUT: api/Department/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, UpdateDepartmentDto dto)
        {
            if (id != dto.DepartmentId)
                return BadRequest(new
                {
                    Message = "Department ID mismatch."
                });

            var department = await _departmentService.UpdateDepartment(dto);

            if (department == null)
                return NotFound(new
                {
                    Message = "Department not found."
                });

            return Ok(department);
        }

        // DELETE: api/Department/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var deleted = await _departmentService.DeleteDepartment(id);

            if (!deleted)
                return NotFound(new
                {
                    Message = "Department not found."
                });

            return Ok(new
            {
                Message = "Department deleted successfully."
            });
        }
    }
}