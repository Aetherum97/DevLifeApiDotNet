using DevLife.Application.Commons.Interfaces.Services;
using DevLife.Application.Commons.Interfaces.Services.Accessors;
using DevLife.Application.Modules.Employees.DTOs;
using DevLife.Application.Modules.Materials.DTOs;
using DevLife.Application.Modules.Materials.DTOs.Requests;
using DevLife.Application.Modules.Materials.Factories;
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
    public class MaterialService(IMaterialRepository materialRepository,
        IMaterialSkillRepository materialSkillRepository,
        IAuthenticatedUserService authenticatedUser,
        IUserCompanyAccessor companyAccessor
        ) : IMaterialService
    {
        public async Task<MaterialDto> CreateAsync(MaterialCreateRequest request)
        {
            var userId = authenticatedUser.GetUserId();

            var materialSkillsId = await GetMaterialSkillsAsync(request.MaterialSkillsId);
            var companyId = await companyAccessor.GetCompanyIdForUserAsync(userId);

            var entity = MaterialDtoFactory.Create(request, materialSkillsId, companyId);

            var result = await materialRepository.AddAsync(entity);
            var response = new MaterialDto(result);
            return response;

        }

        private async Task<MaterialSkill> GetMaterialSkillsAsync(Guid skillId)
        {
            
            var result = await materialSkillRepository.GetByIdAsync(skillId);
            
            return result;
        }

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

        public async Task DeleteAsync(Guid id)
        {
            var toDelete = await materialRepository.GetByIdAsync(id);
            if (toDelete == null)
                throw new InvalidOperationException($"Material {id} not found.");

            await materialRepository.DeleteAsync(toDelete);
        }



    }
}
