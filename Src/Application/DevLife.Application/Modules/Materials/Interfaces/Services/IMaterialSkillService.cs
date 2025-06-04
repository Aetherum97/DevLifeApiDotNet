using DevLife.Application.Modules.Materials.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Modules.Materials.Interfaces.Services
{
    public interface IMaterialSkillService
    {
        Task<List<MaterialSkillDto>> GetAllAsync();
        Task<MaterialSkillDto?> GetByIdAsync(Guid id);
        Task<MaterialSkillDto> CreateAsync(MaterialSkillDto materialSkillDto);

    }
}
