using DevLife.Application.Modules.Employees.DTOs;
using DevLife.Application.Modules.Employees.Interfaces.Repositories;
using DevLife.Application.Modules.Employees.Interfaces.Services;
using DevLife.Domain.Modules.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Modules.Employees.Services;

public class EmployeeSkillService(IEmployeeSkillRepository employeeSkillRepository) : IEmployeeSkillService
{
    public async Task<List<EmployeeSkillDto>> GetAllAsync()
    {
        var result = await employeeSkillRepository.GetAllAsync();

        var response = (result ?? []).Select(item => new EmployeeSkillDto(item)).ToList();
        return response;
    }
}

