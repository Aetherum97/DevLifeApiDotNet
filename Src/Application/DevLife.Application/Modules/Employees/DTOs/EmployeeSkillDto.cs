using System;
using DevLife.Domain.Modules.Employees;

namespace DevLife.Application.Modules.Employees.DTOs;

public class EmployeeSkillDto
{
#pragma warning disable
    public EmployeeSkillDto()
    {

    }
#pragma warning restore

    public EmployeeSkillDto(EmployeeSkill employeeSkill)
    {
        Id = employeeSkill.Id;
        Name = employeeSkill.Name;
        Description = employeeSkill.Description;
        SkillModificator = employeeSkill.SkillModificators?
            .Select(SkillModificators => new EmployeeSkillModificatorDto(SkillModificators))
            .ToList() ?? [];
    }

    
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<EmployeeSkillModificatorDto> SkillModificator { get; set; }
}
