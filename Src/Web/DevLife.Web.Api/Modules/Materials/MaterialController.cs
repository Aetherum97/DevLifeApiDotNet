using DevLife.Application.Modules.Materials.DTOs;
using DevLife.Application.Modules.Materials.Interfaces.Repositories;
using DevLife.Application.Modules.Materials.Interfaces.Services;
using DevLife.Application.Modules.Materials.Services;
using DevLife.Domain.Modules.Materials;
using DevLife.Shared.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace DevLife.Web.Api.Modules.Materials
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialController(IMaterialService materialService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialDto>>> GetAll()
        {
            var dtos = await materialService.GetAllAsync();
            return Ok(dtos);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<MaterialDto>> GetById(Guid id)
        {
            var dto = await materialService.GetByIdAsync(id);

            if (dto == null)
                return NotFound();

            return Ok(dto);
        }
    }
}
