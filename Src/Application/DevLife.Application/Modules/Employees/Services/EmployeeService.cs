using DevLife.Application.Commons.Interfaces.Services;
using DevLife.Application.Modules.Employees.DTOs;
using DevLife.Application.Modules.Employees.DTOs.Requests;
using DevLife.Application.Modules.Employees.Factories;
using DevLife.Application.Modules.Employees.Interfaces.Repositories;
using DevLife.Application.Modules.Employees.Interfaces.Services;




namespace DevLife.Application.Modules.Employees.Services;

public class EmployeeService(
    IEmployeeRepository employeeRepository,
    IEmployeeSkillRepository employeeSkillRepository,
    IAuthenticatedUserService authenticatedUser
) : IEmployeeService
{
    public async Task<List<EmployeeDto>> GetAllAsync()
    {
        var result = await employeeRepository.GetAllAsync();

        var response = (result ?? []).Select(item => new EmployeeDto(item)).ToList();
        return response;
    }

    public async Task<EmployeeDto> GetByIdAsync(Guid id)
    {
        var result = await employeeRepository.GetByIdAsync(id);

        var response = new EmployeeDto(result);
        return response;
    }

    public async Task<EmployeeDto> CreateAsync(EmployeeCreateRequest request)
    {
        var CompanyId = authenticatedUser.GetCompanyId();

        var employeeSkills = await employeeSkillRepository.GetByIdsAsync(request.EmployeeSkills);
        var entity = EmployeeFactory.Create(request, employeeSkills, CompanyId);
        var result = await employeeRepository.AddAsync(entity);

        var response = new EmployeeDto(result);
        return response;
    }

    public async Task<EmployeeDto> UpdateAsync(EmployeeUpdateRequest request)
    {
        var employeeSkills = await employeeSkillRepository.GetByIdsAsync(request.EmployeeSkills);
        var entity = EmployeeFactory.Update(request, employeeSkills);
        var result = await employeeRepository.UpdateAsync(entity);

        var response = new EmployeeDto(result);
        return response;
    }


    public async Task<EmployeeDto> DeleteAsync(EmployeeDeleteRequest request)
    {
        var companyId = authenticatedUser.GetCompanyId();
        if (companyId != request.CompanyId) throw new UnauthorizedAccessException("not authorized");

        var employee = await employeeRepository.GetByIdAsync(request.Id);
        var result = await employeeRepository.DeleteAsync(employee);

        var response = new EmployeeDto(result);
        return response;
    }



}

