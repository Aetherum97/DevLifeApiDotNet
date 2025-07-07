using System;

namespace DevLife.Application.Commons.DTOs.Requests;

public class ContractAssignmentRequest()
{
    public required Guid EmployeId { get; set; }
    public required Guid ContractId { get; set; }
    public required Guid CompanyId { get; set; }
}

public class ContractAssignmentUpdateRequest()
{
    public required Guid CompanyId { get; set; }
    public required Guid PreviousEmployeId { get; set; }
    public Guid NewEmployeId { get; set; }
    public required Guid PreviousContractId { get; set; }
    public Guid NewContractId { get; set; }
}


