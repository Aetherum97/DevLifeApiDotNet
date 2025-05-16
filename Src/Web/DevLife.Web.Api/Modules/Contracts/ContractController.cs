using DevLife.Application.Modules.Contracts.Interfaces.Services;
using DevLife.Application.Modules.Contracts.Services;
using DevLife.Domain.Modules.Contracts;
using DevLife.Infrastructure.Modules.Contracts.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevLife.Web.Api.Modules.Contracts;

[Route("api/[controller]")]
[ApiController]
public class ContractController(IContractService contractService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Contract>>> GetAll()
    {
        var items = await contractService.GetAllAsync();
        return Ok(items);
    }

}

