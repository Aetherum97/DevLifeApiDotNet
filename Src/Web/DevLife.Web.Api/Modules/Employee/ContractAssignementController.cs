using DevLife.Application.Commons.DTOs;
using DevLife.Application.Commons.DTOs.Requests;
using DevLife.Application.Commons.DTOs.Responses;
using DevLife.Application.Commons.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevLife.Web.Api.Modules.Employee;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ContractAssignementController(IContractAssignmentService contractAssignmentService, IAuthenticatedUserService authenticatedUserService) : ControllerBase
{

    [HttpGet("{companyId:guid}")]
    public async Task<ActionResult<CompanyContractEmployeeDto>> EmployeeGetAllContractAssignment(Guid companyId)
    {
        var userCompanyId = authenticatedUserService.GetCompanyId();

        if (companyId != userCompanyId)
        {
            return Forbid();
        }

        var result = await contractAssignmentService.ContractGetAllAsignment(companyId);
        return Ok(result);

    }

    [HttpPost("contract-get-assignment")]
    public async Task<ActionResult<ContractAssignmentResponse>> EmployeeGetContractAssignment(ContractAssignmentRequest request)
    {
        var userCompanyId = authenticatedUserService.GetCompanyId();

        if (request.CompanyId != userCompanyId)
        {
            return Forbid();
        }

        var result = await contractAssignmentService.ContractGetAsignment(request);
        return Ok(result);

    }

    [HttpPost("contract-create-assignment")]
    public async Task<ActionResult<ContractAssignmentResponse>> EmployeeCreateContractAssignment(ContractAssignmentRequest request)
    {
        var userCompanyId = authenticatedUserService.GetCompanyId();

        if (request.CompanyId != userCompanyId)
        {
            return Forbid();
        }

        var result = await contractAssignmentService.ContractCreateAsignment(request);
        return Ok(result);

    }

    [HttpPut("contract-update-assignment")]
    public async Task<ActionResult<ContractAssignmentResponse>> EmployeeUpdateContractAssignment(ContractAssignmentUpdateRequest request)
    {
        var userCompanyId = authenticatedUserService.GetCompanyId();

        if (request.CompanyId != userCompanyId)
        {
            return Forbid();
        }

        var result = await contractAssignmentService.ContractUpdateAsignment(request);
        return Ok(result);

    }

    [HttpDelete("contract-delete-assignment")]
    public async Task<ActionResult<ContractAssignmentResponse>> EmployeeDeleteContractAssignment(ContractAssignmentRequest request)
    {
        var userCompanyId = authenticatedUserService.GetCompanyId();

        if (request.CompanyId != userCompanyId)
        {
            return Forbid();
        }

        var result = await contractAssignmentService.ContractDeleteAsignment(request);
        return Ok(result);

    }
}
