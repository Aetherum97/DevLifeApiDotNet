using DevLife.Application.Modules.Companies.DTOs;
using DevLife.Application.Modules.Companies.Interfaces.Repositories;
using DevLife.Domain.Modules.Companies;
using DevLife.Infrastructure.Modules.Companies.Repositories;
using DevLife.Shared.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace DevLife.Web.Api.Modules.Companies
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController(ICompanyRepository companyRepository, ICustomMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetAll()
        {
            var companies = await companyRepository.GetAllAsync();
            var dtos = companies.Select(c => mapper.Map<Company,CompanyDto>(c!));
            return Ok(dtos);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CompanyDto>> GetById(Guid id)
        {
            var entity = await companyRepository.GetByIdAsync(id);

            var dto = mapper.Map<Company, CompanyDto>(entity);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<CompanyDto>> Create([FromBody] CompanyDto dto)
        {
            var entity = mapper.Map<CompanyDto, Company>(dto);
            var created = await companyRepository.AddAsync(entity);
            var resultDto = mapper.Map<Company, CompanyDto>(created);
            return CreatedAtAction(nameof(GetById), new { id = resultDto.Id }, resultDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CompanyDto>> Update(Guid id, [FromBody] CompanyDto companyDto)
        {
            if (id != companyDto.Id)
                return BadRequest("URL's ID not corresponds");

            var existing = await companyRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            var toUpdate = mapper.Map<CompanyDto, Company>(companyDto);
            var updated = await companyRepository.UpdateAsync(toUpdate);
            var updatedDto = mapper.Map<Company, CompanyDto>(updated);
            return Ok(updatedDto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existing = await companyRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await companyRepository.DeleteAsync(existing);
            return NoContent();
        }
    }
}
