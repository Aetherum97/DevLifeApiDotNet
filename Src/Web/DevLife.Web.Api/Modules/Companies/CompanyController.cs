using DevLife.Application.Modules.Companies.DTOs;
using DevLife.Application.Modules.Companies.Interfaces.Repositories;
using DevLife.Application.Modules.Companies.Interfaces.Services;
using DevLife.Application.Modules.Companies.Services;
using DevLife.Domain.Modules.Companies;
using DevLife.Infrastructure.Modules.Companies.Repositories;
using DevLife.Shared.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace DevLife.Web.Api.Modules.Companies
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController(ICompanyService companyService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetAllAsync()
        {
            var companies = await companyService.GetAllAsync();
            return Ok(companies);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CompanyDto>> GetById(Guid id)
        {
            var dto = await companyService.GetByIdAsync(id);
            if (dto == null)
                return NotFound();
            return Ok(dto);
        }
    }
}
