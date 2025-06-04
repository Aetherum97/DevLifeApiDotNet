using DevLife.Application.Modules.Employees.DTOs;
using DevLife.Application.Modules.Employees.Interfaces.Services;
using DevLife.Application.Modules.Employees.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevLife.Web.Api.Modules.Employee;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController(IEmployeeService employeeService) : ControllerBase
{
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<List<EmployeeDto>>> GetAll()
    {
        var response = await employeeService.GetAllAsync();
        return Ok(response);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<EmployeeDto>> Create(EmployeeCreateRequest request)
    {

        var result = await employeeService.CreateAsync(request);
        return Ok(result);

    }
}

