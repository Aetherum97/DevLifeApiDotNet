using System;
using DevLife.Domain.Modules.Employees;

namespace DevLife.Application.Modules.Employees.DTOs;

public class EmployeeNameDto
{
#pragma warning disable
    public EmployeeNameDto()
    {

    }
#pragma warning restore

    public EmployeeNameDto(EmployeeName employeeName)
    {
        Id = employeeName.Id;
        Name = employeeName.Name;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
}
