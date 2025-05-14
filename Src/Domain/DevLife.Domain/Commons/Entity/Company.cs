using System;
using DevLife.Domain.Commons.Bases;
using DevLife.Domain.Modules.Companies;

namespace DevLife.Domain.Commons.Entity;

public class Company : AuditableBaseEntity
{

    public required string Name { get; set; }
    public required int Experience { get; set; }

    // relations
    public Player? Player { get; set; }
    // TODO relation with material_company

}
