using DevLife.Application.Modules.Employees.DTOs;
using DevLife.Application.Modules.Employees.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevLife.Web.Api.Modules.Employee;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController(IEmployeeService employeeService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<EmployeeDto>>> GetAll()
    {
        var response = await employeeService.GetAllAsync();
        return Ok(response);
    }
}

