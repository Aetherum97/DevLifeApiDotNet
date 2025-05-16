using DevLife.Application.Modules.Contracts.DTOs;
using DevLife.Application.Modules.Contracts.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevLife.Web.Api.Modules.Contracts;

[Route("api/[controller]")]
[ApiController]
public class ContractController(IContractService contractService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<ContractDto>>> GetAll()
    {
        var response = await contractService.GetAllAsync();
        return Ok(response);
    }

}

