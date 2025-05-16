using DevLife.Domain.Modules.Materials;

namespace DevLife.Application.Modules.Materials.Interfaces.Services;

public interface IMaterialService
{
    Task<List<Material>> GetAllAsync();
}
