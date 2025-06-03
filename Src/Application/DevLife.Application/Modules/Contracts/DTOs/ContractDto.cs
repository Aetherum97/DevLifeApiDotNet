using System;
using DevLife.Domain.Modules.Contracts;

namespace DevLife.Application.Modules.Contracts.DTOs;

public class ContractDto
{
#pragma warning disable
    public ContractDto()
    {

    }
#pragma warning restore

    public ContractDto(Contract contract)
    {
        Id = contract.Id;
        Title = contract.ContractTemplate.Title;
        Type = new ContractTypeDto(contract.ContractTemplate.ContractTypes!);
        ContractCompany = contract.CompanyContract.CompanyId;
        AssignedEmployees = contract.CompanyContract.AssignedEmployees?
            .Select(e => e.EmployeeId)
            .ToList() ?? [];

        ImageUrl = contract.ContractTemplate.ImageUrl;
        Description = contract.ContractTemplate.Description;
        Deadline = contract.Deadline;
        StartDate = contract.StartDate;
        IsAccepted = contract.IsAccepted;
        IsCompleted = contract.IsCompleted;
        Progress = contract.Progress;
        Reward = contract.Reward;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public ContractTypeDto Type { get; set; }
    public Guid ContractCompany { get; set; }
    public ICollection<Guid> AssignedEmployees { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public DateTime StartDate { get; set; }
    public bool? IsAccepted { get; set; }
    public bool? IsCompleted { get; set; }
    public int? Progress { get; set; }
    public int Reward { get; set; }
}
