using DevLife.Application.Commons.Interfaces.Repositories;
using DevLife.Application.Commons.Interfaces.Services;
using DevLife.Application.Commons.Interfaces.Services.Accessors;
using DevLife.Application.Modules.Companies.Interfaces.Repositories;
using DevLife.Application.Modules.Employees.DTOs;
using DevLife.Application.Modules.Employees.Interfaces.Repositories;
using DevLife.Application.Modules.Materials.DTOs;
using DevLife.Application.Modules.Materials.DTOs.Requests;
using DevLife.Application.Modules.Materials.DTOs.Responses;
using DevLife.Application.Modules.Materials.Factories;
using DevLife.Application.Modules.Materials.Interfaces.Repositories;
using DevLife.Application.Modules.Materials.Interfaces.Services;
using DevLife.Domain.Commons.Entity;
using DevLife.Domain.Modules.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Application.Modules.Materials.Services
{
    public class MaterialService(IMaterialRepository materialRepository, 
        ICompanyMaterialEmployeeRepository companyMaterialEmployeeRepository,
        ICompanyRepository companyRepository,
        IEmployeeRepository employeeRepository,
        IAuthenticatedUserService authenticatedUserService
        ) : IMaterialService
    {
        public async Task<MaterialDto> CreateAsync(MaterialCreateRequest request)
        {
            var companyId = authenticatedUserService.GetCompanyId();

            var entity = MaterialDtoFactory.Create(request, companyId);

            var result = await materialRepository.AddAsync(entity);
            var response = new MaterialDto(result);

            return response;

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
        public async Task<ToggleMaterialAssignmentDto> ToggleAssignmentAsync(Guid materialId, Guid employeeId)
        {
            var companyId = authenticatedUserService.GetCompanyId();

            await ValidateEntitiesAsync(companyId, materialId, employeeId);

            var isNowAssigned = await companyMaterialEmployeeRepository.ToggleAssignmentAsync(companyId, materialId, employeeId);

            return new ToggleMaterialAssignmentDto
            {
                MaterialId = materialId,
                EmployeeId = employeeId,
                IsAssigned = isNowAssigned
            };
        }

        public async Task DeleteAsync(Guid id)
        { 
            var toDelete = await materialRepository.GetByIdAsync(id);
            if (toDelete == null)
                throw new InvalidOperationException($"Material {id} not found.");

            await materialRepository.DeleteAsync(toDelete);
        }

        private async Task ValidateEntitiesAsync(Guid companyId, Guid materialId, Guid employeeId)
        {
            var companyExists = await companyRepository.GetByIdAsync(companyId);
            if (companyExists == null)
                throw new InvalidOperationException($"Company {companyId} not found.");

            var materialExists = await materialRepository.GetByIdAsync(materialId);
            if (materialExists == null)
                throw new InvalidOperationException($"Material {materialId} not found.");

            var employeeExists = await employeeRepository.GetByIdAsync(employeeId);
            if (employeeExists == null)
                throw new InvalidOperationException($"Employee {employeeId} not found.");
        }

    }
}
