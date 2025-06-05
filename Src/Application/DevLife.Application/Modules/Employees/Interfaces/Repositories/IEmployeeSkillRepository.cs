using System;
using DevLife.Application.Commons.Interfaces.Repositories;
using DevLife.Domain.Modules.Employees;

namespace DevLife.Application.Modules.Employees.Interfaces.Repositories;

public interface IEmployeeSkillRepository : IBaseRepository<EmployeeSkill>
{
    Task<List<EmployeeSkill>> GetEmployeeSkillsAsync(IEnumerable<Guid> skillIds);
}
