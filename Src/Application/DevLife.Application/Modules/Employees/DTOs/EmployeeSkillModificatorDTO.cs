using System;
using DevLife.Domain.Modules.Employees;

namespace DevLife.Application.Modules.Employees.DTOs;

public class EmployeeSkillModificatorDto
{
#pragma warning disable
    public EmployeeSkillModificatorDto()
    {

    }
#pragma warning restore

    public EmployeeSkillModificatorDto(EmployeeSkillModificator EmployeeSkillModificator)
    {
        Id = EmployeeSkillModificator.Id;
        Name = EmployeeSkillModificator.Name;
        Description = EmployeeSkillModificator.Description;
        Modificator = EmployeeSkillModificator.Modificator;

    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Modificator { get; set; }
}

