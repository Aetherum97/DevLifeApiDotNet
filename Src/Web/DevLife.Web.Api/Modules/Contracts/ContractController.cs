using DevLife.Application.Modules.Contracts.DTOs;
using DevLife.Application.Modules.Contracts.DTOs.Requests;
using DevLife.Application.Modules.Contracts.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevLife.Web.Api.Modules.Contracts;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ContractController(IContractService contractService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<ContractDto>>> GetAll()
    {
        var response = await contractService.GetAllByCompanyIdAsync();
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ContractDto>> GetById(Guid id)
    {
        var response = await contractService.GetByIdAsync(id);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<ContractDto>> Create(ContractCreateRequest request)
    {

        var result = await contractService.CreateAsync(request);
        return Ok(result);

    }

    [HttpPut]
    public async Task<ActionResult<ContractDto>> Update(ContractUpdateRequest request)
    {

        var result = await contractService.UpdateAsync(request);
        return Ok(result);

    }

    [HttpDelete("{contractId:guid}")]
    public async Task<ActionResult<ContractDto>> Delete(Guid contractId, ContractDeleteRequest request)
    {

        if (contractId != request.Id)
        {
            return BadRequest("Employee ID in the URL does not match the ID in the request.");
        }

        var result = await contractService.DeleteAsync(request);
        return Ok(result);

    }

}

