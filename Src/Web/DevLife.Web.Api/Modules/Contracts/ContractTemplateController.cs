using DevLife.Application.Modules.Contracts.Interfaces.Services;
using DevLife.Domain.Modules.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevLife.Web.Api.Modules.Contracts
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractTemplateController(IContractTemplateService contractTemplateService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<ContractTemplate>>> GetAll()
        {
            var items = await contractTemplateService.GetAllAsync();
            return Ok(items);
        }
    }
}
