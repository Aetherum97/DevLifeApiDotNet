using System;
using DevLife.Domain.Commons.Bases;
using DevLife.Domain.Commons.Entity;
using DevLife.Domain.Modules.Contracts.Entity;
using DevLife.Domain.Modules.Materials.Entity;
using DevLife.Domain.Modules.Players;


namespace DevLife.Domain.Modules.Companies;

public class Company : AuditableBaseEntity
{
    public required string Name { get; set; }
    public required int Experience { get; set; }

    // Relations
    public Player? Player { get; set; }
    public ICollection<CompanyEmployee>? CompanyEmployees { get; set; }
    public ICollection<CompanyContractEmployee>? CompanyContractEmployees { get; set; }
    public ICollection<CompanyMaterialEmployee>? CompanyMaterialEmployees { get; set; }

}
