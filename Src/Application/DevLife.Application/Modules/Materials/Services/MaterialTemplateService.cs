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
    public class MaterialTemplateService(IMaterialTemplateRepository materialTemplateRepository) : IMaterialTemplateService
    {
        public Task<MaterialTemplateDto> CreateAsync(MaterialTemplateDto materialTemplateDto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MaterialTemplateDto>> GetAllAsync()
        {
            var result = await materialTemplateRepository.GetAllAsync();
            var response = (result ?? []).Select(item => new MaterialTemplateDto(item)).ToList();
            return response;
        }

        public async Task<MaterialTemplateDto?> GetByIdAsync(Guid id)
        {
            var result = await materialTemplateRepository.GetByIdAsync(id);
            if (result is null)
            {
                return null;
            }
            return new MaterialTemplateDto(result);
        }
    }
}
