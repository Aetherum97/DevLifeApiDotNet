using System;
using DevLife.Domain.Modules.Contracts;

namespace DevLife.Application.Modules.Contracts.DTOs;

public class ContractTemplateDto
{
#pragma warning disable
    public ContractTemplateDto()
    {

    }
#pragma warning restore

    public ContractTemplateDto(ContractTemplate contractTemplate)
    {
        Id = contractTemplate.Id;
        Title = contractTemplate.Title;
        ImageUrl = contractTemplate.ImageUrl;
        Description = contractTemplate.Description;
        Type = new ContractTypeDto(contractTemplate.ContractTypes!);
    }

    public Guid Id { get; set; }
    public ContractTypeDto Type { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
}
