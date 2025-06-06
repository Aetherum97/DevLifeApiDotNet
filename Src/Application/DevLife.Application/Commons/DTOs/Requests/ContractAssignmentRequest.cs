using System;

namespace DevLife.Application.Commons.DTOs.Requests;

public class ContractAssignmentRequest()
{
    public required Guid EmployeId { get; set; }
    public required Guid ContractId { get; set; }
    public required Guid CompanyId { get; set; }
}

