using HealthcareApi.Data;
using HealthcareApi.Repository.Interface;
using HealthcareApi.Services.DTOs.Department;
using HealthcareAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthcareApi.Repository.Implementation
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Department> AddAsync(Department dto)
        {
            _context.Departments.Add(dto);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department?> GetDepartmentById(int id)
        {
            return await _context.Departments
                .FirstOrDefaultAsync(x => x.DepartmentId == id);
        }

        public async Task<Department> AddDepartment(Department dto)
        {
            _context.Departments.Add(dto);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task<Department?> UpdateDepartment(Department department)
        {
            var existingDepartment = await _context.Departments
                .FirstOrDefaultAsync(x => x.DepartmentId == department.DepartmentId);

            if (existingDepartment == null)
                return null;

            existingDepartment.DepartmentName = department.DepartmentName;

            await _context.SaveChangesAsync();

            return existingDepartment;
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
                return false;

            _context.Departments.Remove(department);

            await _context.SaveChangesAsync();

            return true;
        }

        async Task<IEnumerable<object>> IDepartmentRepository.GetAllAsync()
        {
            return await _context.Departments.ToListAsync();
        }
    }
}



