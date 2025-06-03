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

public class EmployeeNameService(IEmployeeNameRepository employeeNameRepository) : IEmployeeNameService
{
    public async Task<List<EmployeeNameDto>> GetAllAsync()
    {
        var result = await employeeNameRepository.GetAllAsync();

        var response = (result ?? []).Select(item => new EmployeeNameDto(item)).ToList();
        return response;
    }
}

