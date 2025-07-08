using DevLife.Application.Modules.Employees.DTOs;
using DevLife.Application.Modules.Employees.DTOs.Requests;
using DevLife.Application.Modules.Employees.Services;
using DevLife.Application.Modules.Materials.DTOs;
using DevLife.Application.Modules.Materials.DTOs.Requests;
using DevLife.Application.Modules.Materials.Interfaces.Repositories;
using DevLife.Application.Modules.Materials.Interfaces.Services;
using DevLife.Application.Modules.Materials.Services;
using DevLife.Domain.Modules.Materials;
using DevLife.Shared.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DevLife.Web.Api.Modules.Materials
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialController(IMaterialService materialService) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<MaterialDto>> Create(MaterialCreateRequest request)
        {
            var result = await materialService.CreateAsync(request);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialDto>>> GetAll()
        {
            var dtos = await materialService.GetAllByCompanyIdAsync();
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

        [HttpPut("{id:guid}/toggle-assignment/{employeeId:guid}")]
        public async Task<IActionResult> ToggleAssignment(Guid id, Guid employeeId)
        {
            var result = await materialService.ToggleAssignmentAsync(id, employeeId);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await materialService.DeleteAsync(id);
                return NoContent();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
    }
}
