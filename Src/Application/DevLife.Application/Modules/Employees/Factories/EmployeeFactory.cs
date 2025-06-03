using System;
using System.Runtime.InteropServices;
using DevLife.Application.Modules.Employees.DTOs;
using DevLife.Application.Modules.Employees.Services;
using DevLife.Domain.Modules.Employees;

namespace DevLife.Application.Modules.Employees.Factories;

public static class EmployeeDtoFactory
{

    public static Employee Create(EmployeeCreateRequest request, ICollection<EmployeeSkill> employeeSkills)
    {

        var result = new Employee
        {
            EmployeeNameId = request.EmployeeNameId,
            Salary = request.Salary,
            Experience = request.Experience,
            Level = request.Level,
            CFrontEnd = request.CFrontEnd,
            CBackEnd = request.CBackEnd,
            CDevops = request.CDevops,
            CDatabase = request.CDatabase,
            IsAvalaible = request.IsAvalaible,
            EmployeeSkills = employeeSkills,
        };

        return result;
    }

}
