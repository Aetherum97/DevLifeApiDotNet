using DevLife.Application.Modules.Employees.DTOs;
using DevLife.Application.Modules.Employees.Interfaces.Repositories;
using DevLife.Application.Modules.Employees.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Modules.Employees.Services;

public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
{
    public async Task<List<EmployeeDto>> GetAllAsync()
    {
        var result = await employeeRepository.GetAllAsync();

        var response = (result ?? []).Select(item => new EmployeeDto(item)).ToList();
        return response;
    }
}

