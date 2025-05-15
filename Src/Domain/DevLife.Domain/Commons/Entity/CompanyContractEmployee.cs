using System;
using DevLife.Domain.Commons.Bases;


namespace DevLife.Domain.Commons.Entity;

public class CompanyContractEmployee : BaseEntity
{
    public Guid CompanyId { get; set; }
    public Guid EmployeeId { get; set; }
    public Guid ContractId { get; set; }
    public CompanyContract? CompanyContract { get; set; }
    public CompanyEmployee? CompanyEmployee { get; set; }
}
