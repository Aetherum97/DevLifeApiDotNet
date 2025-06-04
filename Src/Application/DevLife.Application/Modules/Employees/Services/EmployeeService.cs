using DevLife.Application.Commons.Interfaces.Services;
using DevLife.Application.Commons.Interfaces.Services.Accessors;
using DevLife.Application.Modules.Employees.DTOs;
using DevLife.Application.Modules.Employees.Factories;
using DevLife.Application.Modules.Employees.Interfaces.Repositories;
using DevLife.Application.Modules.Employees.Interfaces.Services;
using DevLife.Domain.Modules.Employees;

namespace DevLife.Application.Modules.Employees.Services;

public class EmployeeService(
    IEmployeeRepository employeeRepository,
    IEmployeeSkillRepository employeeSkillRepository,
    IAuthenticatedUserService authenticatedUser,
    IUserCompanyAccessor companyAccessor
) : IEmployeeService
{
    public async Task<List<EmployeeDto>> GetAllAsync()
    {
        var result = await employeeRepository.GetAllAsync();

        var response = (result ?? []).Select(item => new EmployeeDto(item)).ToList();
        return response;
    }

    public async Task<EmployeeDto> CreateAsync(EmployeeCreateRequest request)
    {
        var userId = await authenticatedUser.GetAdminUserIdInDevelopmentAsync() ?? authenticatedUser.GetUserId();

        var employeeSkills = await GetEmployeeSkillsAsync(request.EmployeeSkills);
        var CompanyId = await companyAccessor.GetCompanyIdForUserAsync(userId);

        var entity = EmployeeDtoFactory.Create(request, employeeSkills, CompanyId);
        
        var result = await employeeRepository.AddAsync(entity);
        var response = new EmployeeDto(result);

        return response;
    }

    private async Task<List<EmployeeSkill>> GetEmployeeSkillsAsync(IEnumerable<Guid> skillIds)
    {
        var skillTasks = skillIds.Select(async id =>
        {
            var skill = await employeeSkillRepository.GetByIdAsync(id);
            return skill;
        });

        var result = (await Task.WhenAll(skillTasks)).ToList();

        return result;
    }
}

public class EmployeeCreateRequest()
{
    public required Guid CompanyId { get; set; }
    public required Guid EmployeeNameId { get; set; }
    public required ICollection<Guid> EmployeeSkills { get; set; }
    public required int Level { get; set; }
    public required int Salary { get; set; }
    public required int Experience { get; set; }
    public required int CFrontEnd { get; set; }
    public required int CBackEnd { get; set; }
    public required int CDevops { get; set; }
    public required int CDatabase { get; set; }
    public required bool IsAvalaible { get; set; }
}
