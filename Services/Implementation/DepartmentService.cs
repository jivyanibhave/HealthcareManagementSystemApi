using HealthcareApi.Models;
using HealthcareApi.Repository.Interface;
using HealthcareApi.Services.DTOs.Department;
using HealthcareApi.Services.Interface;
using HealthcareAPI.Models;

namespace HealthcareApi.Services.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DepartmentResponseDto>> GetAllDepartments()
        {
            var departments = await _repository.GetAllDepartments();

            //return departments.Select(static d => new DepartmentResponseDto
            //{
            //    DepartmentId = (int)GetDepartmentId(d),
            //    DepartmentName = GetDepartmentName(d)
            //});

            return departments.Select(d => new DepartmentResponseDto
            {
                DepartmentId = d.DepartmentId,
                DepartmentName = d.DepartmentName
            });
        }

    
        public async Task<DepartmentResponseDto?> GetDepartmentById(int id)
        {
            var department = await _repository.GetDepartmentById(id);

            if (department == null)
                return null;

            return new DepartmentResponseDto
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName
            };
        }

        public async Task<DepartmentResponseDto> AddDepartment(CreateDepartmentDto dto)
        {
            Department dep = new Department
            {
                DepartmentName = dto.DepartmentName,
            };
            var departments = await _repository.AddDepartment(dep);

            return new DepartmentResponseDto
            {
                DepartmentId = dep.DepartmentId,
                DepartmentName = dep.DepartmentName
            };

        }

        public async Task<DepartmentResponseDto?> UpdateDepartment(UpdateDepartmentDto dto)
        {
            var department = new Department
            {
                DepartmentId = dto.DepartmentId,
                DepartmentName = dto.DepartmentName
            };

            var result = await _repository.UpdateDepartment(department);

            if (result == null)
                return null;

            return new DepartmentResponseDto
            {
                DepartmentId = result.DepartmentId,
                DepartmentName = result.DepartmentName
            };
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            return await _repository.DeleteDepartment(id);
        }
    }
}