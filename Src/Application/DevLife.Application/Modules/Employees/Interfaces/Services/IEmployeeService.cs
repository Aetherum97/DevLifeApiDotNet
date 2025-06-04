using DevLife.Application.Modules.Employees.DTOs;
using DevLife.Application.Modules.Employees.DTOs.Requests;

namespace DevLife.Application.Modules.Employees.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto> GetByIdAsync(Guid id);
        Task<EmployeeDto> CreateAsync(EmployeeCreateRequest request);
        Task<EmployeeDto> UpdateAsync(EmployeeUpdateRequest request);
        Task<EmployeeDto> DeleteAsync(EmployeeDeleteRequest request);
    }
}
