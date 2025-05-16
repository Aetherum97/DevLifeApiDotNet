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
    public class MaterialSkillService : IMaterialSkillService
    {
        private readonly IMaterialSkillRepository _materialSkillRepository;

        public MaterialSkillService(IMaterialSkillRepository materialSkillRepository)
        {
            _materialSkillRepository = materialSkillRepository;
        }

        public async Task<List<MaterialSkill>> GetAllAsync()
        {
            return await _materialSkillRepository.GetAllAsync();
        }
    }
}
