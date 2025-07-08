using DevLife.Application.Modules.Materials.DTOs;
using DevLife.Application.Modules.Materials.DTOs.Requests;
using DevLife.Application.Modules.Materials.DTOs.Responses;

namespace DevLife.Application.Modules.Materials.Interfaces.Services;

public interface IMaterialService
{
    Task<List<MaterialDto>> GetAllByCompanyIdAsync();
    Task<MaterialDto?> GetByIdAsync(Guid id);
    Task<MaterialDto> CreateAsync(MaterialCreateRequest materialDto);
    Task<ToggleMaterialAssignmentDto> ToggleAssignmentAsync(Guid materialId, Guid employeeId);
    Task DeleteAsync(Guid id);

}
