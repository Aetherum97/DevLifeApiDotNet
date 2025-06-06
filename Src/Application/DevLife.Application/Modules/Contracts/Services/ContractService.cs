using DevLife.Application.Commons.Interfaces.Services;
using DevLife.Application.Modules.Contracts.DTOs;
using DevLife.Application.Modules.Contracts.DTOs.Requests;
using DevLife.Application.Modules.Contracts.Factories;
using DevLife.Application.Modules.Contracts.Interfaces.Repositories;
using DevLife.Application.Modules.Contracts.Interfaces.Services;
using DevLife.Domain.Modules.Contracts;

namespace DevLife.Application.Modules.Contracts.Services;

public class ContractService(
    IContractRepository contractRepository,
    IReferenceDataCacheService referenceDataCache,
    IAuthenticatedUserService authenticatedUser

) : IContractService
{
    public async Task<List<ContractDto>> GetAllAsync()
    {
        var result = await contractRepository.GetAllAsync();

        var response = (result ?? []).Select(item => new ContractDto(item)).ToList();
        return response;
    }
    public async Task<ContractDto> GetByIdAsync(Guid id)
    {
        var result = await contractRepository.GetByIdAsync(id);

        var response = new ContractDto(result);
        return response;
    }

    public async Task<ContractDto> CreateAsync(ContractCreateRequest request)
    {
        var companyId = authenticatedUser.GetCompanyId();
        var contractTemplate = referenceDataCache.GetById<ContractTemplate>(request.ContractTemplateId) ??
            throw new KeyNotFoundException($"ContractTemplate with ID {request.ContractTemplateId} was not found.");

        var entity = ContractFactory.Create(request, contractTemplate, companyId);
        var result = await contractRepository.AddAsync(entity);

        var response = new ContractDto(result);
        return response;
    }

    public async Task<ContractDto> UpdateAsync(ContractUpdateRequest request)
    {
        var entity = await contractRepository.GetByIdAsync(request.Id);

        entity.Deadline = request.Deadline;
        entity.StartDate = request.StartDate;
        entity.IsAccepted = request.IsAccepted;
        entity.IsCompleted = request.IsCompleted;
        entity.Progress = request.Progress;
        entity.Reward = request.Reward;


        var result = await contractRepository.UpdateAsync(entity);

        var response = new ContractDto(result);
        return response;
    }

    public async Task<ContractDto> DeleteAsync(ContractDeleteRequest request)
    {
        var companyId = authenticatedUser.GetCompanyId();
        if (companyId != request.CompanyId) throw new UnauthorizedAccessException("not authorized");

        var contract = await contractRepository.GetByIdAsync(request.Id);
        var result = await contractRepository.DeleteAsync(contract);

        var response = new ContractDto(result);
        return response;
    }
}

