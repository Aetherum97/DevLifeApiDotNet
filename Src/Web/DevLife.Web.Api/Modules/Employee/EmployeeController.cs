using DevLife.Application.Commons.DTOs.Requests;
using DevLife.Application.Commons.DTOs.Responses;
using DevLife.Application.Commons.Interfaces.Services;
using DevLife.Application.Modules.Employees.DTOs;
using DevLife.Application.Modules.Employees.DTOs.Requests;
using DevLife.Application.Modules.Employees.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevLife.Web.Api.Modules.Employee;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class EmployeeController(IEmployeeService employeeService, IContractAssignmentService contractAssignmentService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<EmployeeDto>>> GetAll()
    {
        var response = await employeeService.GetAllAsync();
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<List<EmployeeDto>>> GetById(Guid id)
    {
        var response = await employeeService.GetByIdAsync(id);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<EmployeeDto>> Create(EmployeeCreateRequest request)
    {

        var result = await employeeService.CreateAsync(request);
        return Ok(result);

    }

    [HttpPost("contract-assignment")]
    public async Task<ActionResult<ContractAssignmentResponse>> EmployeeContractAssignment(ContractAssignmentRequest request)
    {

        var result = await contractAssignmentService.ContractAsignment(request);
        return Ok(result);

    }

    [HttpPut]
    public async Task<ActionResult<EmployeeDto>> Update(EmployeeUpdateRequest request)
    {

        var result = await employeeService.UpdateAsync(request);
        return Ok(result);

    }

    [HttpDelete("{employeId:guid}")]
    public async Task<ActionResult<EmployeeDto>> Delete(Guid employeId, EmployeeDeleteRequest request)
    {

        if (employeId != request.Id)
        {
            return BadRequest("Employee ID in the URL does not match the ID in the request.");
        }

        var result = await employeeService.DeleteAsync(request);
        return Ok(result);

    }
}

