using HealthcareApi.Services.DTOs.Department;

namespace HealthcareApi.Services.Interface
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentResponseDto>> GetAllDepartments();

        Task<DepartmentResponseDto?> GetDepartmentById(int id);

        Task<DepartmentResponseDto> AddDepartment(CreateDepartmentDto dto);

        Task<DepartmentResponseDto?> UpdateDepartment(UpdateDepartmentDto dto);

        Task<bool> DeleteDepartment(int id);
    }
}