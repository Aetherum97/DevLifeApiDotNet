using DevLife.Application.Modules.Materials.DTOs;
using DevLife.Application.Modules.Materials.Interfaces.Repositories;
using DevLife.Application.Modules.Materials.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Modules.Materials.Services
{
    public class MaterialSkillService(IMaterialSkillRepository materialSkillRepository) : IMaterialSkillService
    {
        public async Task<List<MaterialSkillDto>> GetAllAsync()
        {
            var result = await materialSkillRepository.GetAllAsync();
            var response = (result ?? []).Select(item => new MaterialSkillDto(item)).ToList();
            return response;
        }
    }
}
