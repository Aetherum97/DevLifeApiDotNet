using DevLife.Application.Modules.Materials.DTOs;

namespace DevLife.Application.Modules.Materials.Interfaces.Services;

public interface IMaterialService
{
    Task<List<MaterialDto>> GetAllAsync();
    Task<MaterialDto?> GetByIdAsync(Guid id);
    Task<MaterialDto> CreateAsync(MaterialDto materialDto);
}
