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
        public async Task<List<Material>> GetAllAsync()
        {
            return await materialRepository.GetAllAsync();
        }
    }
}
