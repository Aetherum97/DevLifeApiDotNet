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
    public class MaterialTemplateService : IMaterialTemplateService
    {
        private readonly IMaterialTemplateRepository _materialTemplateRepository;

        public MaterialTemplateService(IMaterialTemplateRepository materialTemplateRepository)
        {
            _materialTemplateRepository = materialTemplateRepository;
        }

        public async Task<List<MaterialTemplate>> GetAllAsync()
        {
            return await _materialTemplateRepository.GetAllAsync();
        }
    }
}
