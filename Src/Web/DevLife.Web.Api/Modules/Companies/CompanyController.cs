using DevLife.Application.Modules.Companies.DTOs;
using DevLife.Application.Modules.Companies.Interfaces.Repositories;
using DevLife.Application.Modules.Companies.Interfaces.Services;
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
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetAll()
        {
            var companies = await companyService.GetAllAsync();
            return Ok(companies);
        }
    }
}
