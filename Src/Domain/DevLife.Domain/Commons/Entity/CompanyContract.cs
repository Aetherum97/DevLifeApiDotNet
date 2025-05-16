using System;
using DevLife.Domain.Modules.Companies;
using DevLife.Domain.Modules.Contracts;


namespace DevLife.Domain.Commons.Entity;

public class CompanyContract
{
    public Guid ContractId { get; set; }
    public Contract? Contract { get; set; }

    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }

    public ICollection<CompanyContractEmployee>? AssignedEmployees { get; set; }
}

