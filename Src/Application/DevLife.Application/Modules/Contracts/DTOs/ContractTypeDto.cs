using System;
using DevLife.Domain.Modules.Contracts;

namespace DevLife.Application.Modules.Contracts.DTOs;

public class ContractTypeDto
{
#pragma warning disable
    public ContractTypeDto()
    {

    }
#pragma warning restore

    public ContractTypeDto(ContractType contractType)
    {
        Id = contractType.Id;
        Name = contractType.Name;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
}
