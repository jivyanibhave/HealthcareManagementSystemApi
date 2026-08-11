using HealthcareApi.Services.DTOs.Department;
using HealthcareAPI.Models;

namespace HealthcareApi.Repository.Interface
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartments();

        Task<Department?> GetDepartmentById(int id);

        Task<Department> AddDepartment(Department dto);

        Task<Department?> UpdateDepartment(Department department);

        Task<bool> DeleteDepartment(int id);
        Task<IEnumerable<object>> GetAllAsync();
    }
}
