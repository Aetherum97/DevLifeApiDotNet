using DevLife.Application.Modules.Materials.DTOs;
using DevLife.Application.Modules.Materials.Interfaces.Repositories;
using DevLife.Domain.Modules.Materials;
using DevLife.Shared.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace DevLife.Web.Api.Modules.Materials
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialController(IMaterialRepository materialRepository, ICustomMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialDto>>> GetAll()
        {
            var entities = await materialRepository.GetAllAsync();

            var dtos = entities.Select(e => mapper.Map<Material, MaterialDto>(e!));
            return Ok(dtos);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<MaterialDto>> GetById(Guid Id)
        {
            var entity = await materialRepository.GetByIdAsync(Id);
            if (entity == null)
                return NotFound();

            var dto = mapper.Map<Material, MaterialDto>(entity);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<MaterialDto>> Create([FromBody] MaterialDto materialDto)
        {
            var entity = mapper.Map<MaterialDto, Material>(materialDto);
            var created = await materialRepository.AddAsync(entity);

            var createdDto = mapper.Map<Material, MaterialDto>(created);
            return CreatedAtAction(nameof(GetById), new { id = createdDto.Id }, createdDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<MaterialDto>> Update(Guid id, [FromBody] MaterialDto materialDto)
        {
            if (id != materialDto.Id)
                return BadRequest("URL's ID not corresponds");
            var existing = await materialRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            var toUpdate = mapper.Map<MaterialDto, Material>(materialDto);
            var updated = await materialRepository.UpdateAsync(toUpdate);
            var updatedDto = mapper.Map<Material, MaterialDto>(updated);
            return Ok(updatedDto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existing = await materialRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();
            await materialRepository.DeleteAsync(existing);
            return NoContent();
        }
    }
}
