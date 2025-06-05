using DevLife.Application.Modules.Materials.DTOs;
using DevLife.Application.Modules.Materials.DTOs.Requests;

namespace DevLife.Application.Modules.Materials.Interfaces.Services;

public interface IMaterialService
{
    Task<List<MaterialDto>> GetAllAsync();
    Task<MaterialDto?> GetByIdAsync(Guid id);
    Task<MaterialDto> CreateAsync(MaterialCreateRequest materialDto);
    Task DeleteAsync(Guid id);

}
