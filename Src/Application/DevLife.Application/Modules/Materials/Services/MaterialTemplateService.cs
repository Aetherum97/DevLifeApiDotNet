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
        public async Task<List<MaterialTemplate>> GetAllAsync()
        {
            return await materialTemplateRepository.GetAllAsync();
        }
    }
}
