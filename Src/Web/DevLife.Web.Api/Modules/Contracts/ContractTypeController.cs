using DevLife.Application.Modules.Contracts.DTOs;
using DevLife.Application.Modules.Contracts.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevLife.Web.Api.Modules.Contracts
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractTypeController(IContractTypeService contractTypeService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<ContractTypeDto>>> GetAll()
        {
            var items = await contractTypeService.GetAllAsync();
            return Ok(items);
        }
    }
}
