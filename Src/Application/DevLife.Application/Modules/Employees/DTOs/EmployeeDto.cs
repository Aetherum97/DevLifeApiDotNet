using System;
using DevLife.Domain.Modules.Employees;

namespace DevLife.Application.Modules.Employees.DTOs;

public class EmployeeDto
{
#pragma warning disable
    public EmployeeDto()
    {

    }
#pragma warning restore

    public EmployeeDto(Employee employee)
    {
        Id = employee.Id;
        CompanyId = employee.CompanyEmployee.CompanyId;
        Salary = employee.Salary;
        Experience = employee.Experience;
        CFrontEnd = employee.CFrontEnd;
        CBackEnd = employee.CBackEnd;
        CDevops = employee.CDevops;
        CDatabase = employee.CDatabase;
        IsAvalaible = employee.IsAvalaible;
        EmployeeName = new EmployeeNameDto(employee.EmployeeName);
        EmployeeSkills = employee.EmployeeSkills?
            .Select(s => new EmployeeSkillDto(s)).ToList() ?? [];


    }

    public Guid Id { get; set; }
    public Guid CompanyId { get; set; }
    public int Salary { get; set; }
    public int Experience { get; set; }
    public int CFrontEnd { get; set; }
    public int CBackEnd { get; set; }
    public int CDevops { get; set; }
    public int CDatabase { get; set; }
    public bool IsAvalaible { get; set; }
    public EmployeeNameDto EmployeeName { get; set; }
    public ICollection<EmployeeSkillDto>? EmployeeSkills { get; set; }
}
