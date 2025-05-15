using System;
using DevLife.Domain.Commons.Bases;
using DevLife.Domain.Modules.Companies;
using DevLife.Domain.Modules.Contracts.Entity;
using DevLife.Domain.Modules.Employees;

namespace DevLife.Domain.Commons.Entity;

public class CompanyContractEmployee : BaseEntity
{
    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }

    public Guid EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    public Guid ContractId { get; set; }
    public Contract? Contract { get; set; }
}
