using DevLife.Application.Modules.Employees.DTOs;
using DevLife.Application.Modules.Materials.DTOs;
using DevLife.Application.Modules.Materials.Interfaces.Repositories;
using DevLife.Application.Modules.Materials.Interfaces.Services;
using DevLife.Domain.Modules.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Modules.Materials.Services
{
    public class MaterialService(IMaterialRepository materialRepository) : IMaterialService
    {
        public async Task<List<MaterialDto>> GetAllAsync()
        {
            var result = await materialRepository.GetAllAsync();
            var response = (result ?? []).Select(item => new MaterialDto(item)).ToList();
            return response;
        }

        public async Task<MaterialDto?> GetByIdAsync(Guid id)
        {
            var result = await materialRepository.GetByIdAsync(id);
            if (result == null)
                return null;
            return new MaterialDto(result);

        }

    }
}
