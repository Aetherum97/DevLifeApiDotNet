using System;
using System.Runtime.InteropServices;
using DevLife.Application.Modules.Employees.DTOs;
using DevLife.Application.Modules.Employees.Services;
using DevLife.Domain.Commons.Entity;
using DevLife.Domain.Modules.Employees;

namespace DevLife.Application.Modules.Employees.Factories;

public static class EmployeeDtoFactory
{

    public static Employee Create(EmployeeCreateRequest request, ICollection<EmployeeSkill> employeeSkills, Guid companyId)
    {
        var employeeId = Guid.NewGuid();

        var result = new Employee
        {
            Id = employeeId,
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
            CompanyEmployee = new CompanyEmployee
            {
                EmployeeId = employeeId,
                CompanyId = companyId
            }

        };



        return result;
    }

}
