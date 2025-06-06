using System;

namespace DevLife.Application.Modules.Contracts.DTOs.Requests;

public class ContractCreateRequest
{
    public required Guid ContractTemplateId { get; set; }
    public required DateTime Deadline { get; set; }
    public required DateTime StartDate { get; set; }
    public required bool IsAccepted { get; set; }
    public required bool IsCompleted { get; set; }
    public required int Progress { get; set; }
    public required int Reward { get; set; }

}

public class ContractUpdateRequest
{
    public required Guid Id { get; set; }
    public required DateTime Deadline { get; set; }
    public required DateTime StartDate { get; set; }
    public required bool IsAccepted { get; set; }
    public required bool IsCompleted { get; set; }
    public required int Progress { get; set; }
    public required int Reward { get; set; }

}

public class ContractDeleteRequest
{
    public required Guid Id { get; set; }
    public required Guid CompanyId { get; set; }
}
