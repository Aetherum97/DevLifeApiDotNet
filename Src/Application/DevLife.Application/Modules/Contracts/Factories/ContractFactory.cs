using System;
using System.Data.Common;
using DevLife.Application.Modules.Contracts.DTOs.Requests;
using DevLife.Domain.Commons.Entity;
using DevLife.Domain.Modules.Contracts;

namespace DevLife.Application.Modules.Contracts.Factories;

public static class ContractFactory
{
    public static Contract Create(ContractCreateRequest request, ContractTemplate contractTemplate, Guid companyId)
    {
        var id = Guid.NewGuid();

        var result = new Contract
        {
            Id = id,
            ContractTemplateId = contractTemplate.Id,
            Deadline = request.Deadline,
            StartDate = request.StartDate,
            IsAccepted = request.IsAccepted,
            IsCompleted = request.IsCompleted,
            Progress = request.Progress,
            Reward = request.Progress,
            CompanyContract = new CompanyContract
            {
                ContractId = id,
                CompanyId = companyId,
            }
        };

        return result;
    }

}
